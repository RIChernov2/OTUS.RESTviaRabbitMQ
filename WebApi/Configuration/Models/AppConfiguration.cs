
using Data.Repositories.Interfaces;

namespace WebApi.Configuration.Models
{
    public class AppConfiguration : ISchemaCongiguration
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public string FluentMigratorProfile { get; set; }
        public string SchemaName { get; set; }
        public RabbitMq RabbitMq { get; set; }
    }
}
