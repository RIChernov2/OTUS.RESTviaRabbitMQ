using WebApi.Configuration.Models;
using WebApi.MessageBrokerClients;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace WebApi.Configuration
{
    public static class RabbitMqConfiguration
    {
        public static void ConfigureRabbitMQ(this IServiceCollection services, AppConfiguration configuration)
        {
            var rabbitMqSettings = configuration.RabbitMq;
            var connectionFactory = new ConnectionFactory {
                HostName = rabbitMqSettings.Host,
                UserName = rabbitMqSettings.Username,
                Password = rabbitMqSettings.Password
            };
            var rabbitMqConnection = connectionFactory.CreateConnection();
            services.AddSingleton(rabbitMqConnection);

            services.AddSingleton(opt => new MessagesRpcClient(rabbitMqConnection, rabbitMqSettings.MessagesRequestQueue));
        }
    }
} 