using Notifications.Manager.Configurations.Models;
using Notifications.Manager.Managers;
using Notifications.Manager.Providers;
using RabbitMQ.Client;


namespace Notifications.Manager.Configurations
{
    public static class RabbitMqConfiguration
    {
        public static void Configure(AppConfiguration configuration)
        {
            var rabbitMqSettings = configuration.RabbitMq;

            var connectionFactory = new ConnectionFactory
            {
                HostName = rabbitMqSettings.Host,
                UserName = rabbitMqSettings.Username,
                Password = rabbitMqSettings.Password,
                DispatchConsumersAsync = true
            };

            var connection = connectionFactory.CreateConnection();

            var factory = new MessagesFactory(configuration);
            var counsumer = new MessagesProvider(connection, rabbitMqSettings.MessagesRequestQueue, factory);
            counsumer.StartListening();

        }
    }
}