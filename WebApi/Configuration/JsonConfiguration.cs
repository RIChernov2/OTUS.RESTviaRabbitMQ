using Microsoft.Extensions.DependencyInjection;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace WebApi.Configuration
{
    public static class JsonConfiguration
    {
        public static void AddJson(this IServiceCollection services)
        {
            services.AddSingleton(sp => JsonSerializer.CreateDefault());
        }
    }
}