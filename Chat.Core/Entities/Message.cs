using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Entities
{
    public enum MessageType{
        GETUSERS,
        ADDUSER
    };

    public class Message
    {
        public string Id { get; set; }
        public MessageType Type { get; set; }
        public string Content { get; set; }

    }
}
