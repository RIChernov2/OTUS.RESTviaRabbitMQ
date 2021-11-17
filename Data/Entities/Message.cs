using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Message
    {
        public long MessageId { get; set; }
        public long UserId { get; set; }
        public MessageType Type { get; set; }
        public string Text { get; set; }
    }
}
