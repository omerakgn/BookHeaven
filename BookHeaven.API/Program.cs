using Autofac;
using Autofac.Extensions.DependencyInjection;
using BookHeaven.API.Modules;
using BookHeaven.Core.Models;
using BookHeaven.Core.Services;
using BookHeaven.Repository;
using BookHeaven.Service;
using BookHeaven.Service.Filters;
using BookHeaven.Service.Mapping;
using BookHeaven.Service.Services;
using BookHeaven.Service.Validators;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BookHeaven.Service.Services.Storage.Local;
using BookHeaven.Service.Services.Storage.Azure;
using BookHeaven.Service.Services.Storage;
using BookHeaven.Core.Models.Identity;
using BookHeaven.Core.Features.Queries.GetAllProduct;
using MediatR;
using BookHeaven.Core;
using Autofac.Core;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Identity;
using BookHeaven.Service.LocalizeIdentityError;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BookHeaven.Core.Services.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BookHeaven.Core.Services.Authentications;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Security.Claims;
using Serilog.Context;
using BookHeaven.API.Configurations.UsernameEnricher;
using Microsoft.AspNetCore.HttpLogging;
using System.Data;
using BookHeaven.API.Extensions;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateBookValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
    .AddNewtonsoftJson();

builder.Services.AddControllers()
               .AddNewtonsoftJson(options =>
               {
                   // Use the default property (Pascal) casing
                   options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                   options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
               });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddInjectionApplication();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200", "https://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
        .AllowCredentials();
           
    });
});




builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddScoped<BookHeaven.Core.Services.Storage.Local.ILocalStorage, LocalStorage>();

builder.Services.AddScoped<BookHeaven.Core.Services.Storage.Azure.IAzureStorage, AzureStorage>();

builder.Services.AddScoped<BookHeaven.Core.Services.Storage.IStorageManager, StorageManager>();

builder.Services.AddScoped<ITokenHandler, BookHeaven.Service.Services.Token.TokenHandler>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IInternalAuthentication, AuthService>();

builder.Services.AddIdentity<AppUser, AppRole>(options =>
    {
        options.Password.RequiredLength = 3;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
    }).AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders()
     .AddErrorDescriber<TurkishIdentityErrorDescriber>();



builder.Services.AddDbContext<AppDbContext>(x => 
    {
        x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
        {
            option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))?.GetName().Name);
        });
    });

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    containerBuilder.RegisterModule(new RepoServiceModule()));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
       
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
          //  LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,

          //  NameClaimType = ClaimTypes.Name,
          //  RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
        };

        // Eventleri buraya ekliyoruz.
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                // Authentication baþarýsýzsa, hata mesajýný logluyoruz.
                Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                // Token doðrulandýysa, kullanýcý adýný logluyoruz.
                Console.WriteLine($"Token validated for user: {context.Principal.Identity.Name}");
                return Task.CompletedTask;
            }
        };
    });
builder.Services.Configure<AuthenticationOptions>(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("isAdmin", policy => policy
    .RequireAssertion
    (context =>
    {
        return context.User.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "Admin");
    }
    ));

});

builder.Services.AddHttpContextAccessor();

builder.Host.UseSerilog((context, services, configuration) =>
{
    var columnOptions = new ColumnOptions();
    columnOptions.AdditionalColumns = new List<SqlColumn>
    {
        new SqlColumn("UserName", SqlDbType.NVarChar),
        new SqlColumn("LogEvent", SqlDbType.NVarChar)
    };


    configuration
    .Enrich.FromLogContext()
    .Enrich.With<UsernameEnricher>()
    .WriteTo.Console()
    .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("sqlConnection"), "logs",
    autoCreateSqlTable: true,
    columnOptions: columnOptions)
       .MinimumLevel.Information();

});

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.ResponseHeaders.Add("MyResponseHeader");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
    logging.CombineLogs = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.ConfiguraExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());

app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
