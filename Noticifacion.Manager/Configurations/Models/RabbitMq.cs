namespace Notifications.Manager.Configurations.Models
{
    public class RabbitMq
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string MessagesRequestQueue { get; set; }
    }
}