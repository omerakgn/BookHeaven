using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace BookHeaven.API.Configurations.UsernameEnricher
{
    public class UsernameEnricher : ILogEventEnricher
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsernameEnricher() : this(new HttpContextAccessor()){
            
        }

        public UsernameEnricher(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (_httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == true)
            {
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
             "UserName", _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name) ?? "anonymous"));
            }
            else
            {
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("UserName", "Anonymous"));
            }

        }
    }
}
