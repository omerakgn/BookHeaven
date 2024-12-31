using System.Net;
using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace BookHeaven.API.Extensions
{
    static public class ConfigureExceptionHandlerExtension
    {

        public static void ConfiguraExceptionHandler<T>(this WebApplication application, ILogger<T> logger)
        {
            application.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType  = MediaTypeNames.Application.Json;

                    var contextFeauture = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeauture != null) 
                    {
                        logger.LogError(contextFeauture.Error.Message);

                        await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeauture.Error.Message,
                            Title = "Hata Alındı!"

                        }));
                    
                    }

                });

            });

        }

    }
}
