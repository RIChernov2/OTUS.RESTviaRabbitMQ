
using Notifications.Manager.Configurations.Models.Interfaces;

namespace Notifications.Manager.Configurations.Models
{
    public class AppConfiguration//: IAppConfiguration // добавил потестировать
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public string SchemaName { get; set; }
        public string FluentMigratorProfile { get; set; }
        public RabbitMq RabbitMq { get; set; }
    }
}
