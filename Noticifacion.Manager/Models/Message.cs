
namespace Notifications.Manager.Models
{
    public class Message
    {
        public long MessageId { get; set; }
        public long UserId { get; set; }
        public MessageType Type { get; set; }
        public string Text { get; set; }
    }
}
