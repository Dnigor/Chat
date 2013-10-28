using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Commands
{
    public enum CommandType 
    { 
        GETUSERS,
        SENDMESSAGE
    }

    public abstract class ICommand
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Content { get; set; }
    }
}
