using Chat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Services
{
    public interface IMessagingService
    {
        void SendMessage(Message message);        
    }

    public class MessagingService : IMessagingService
    {
        public void SendMessage(Message message)
        { 
        
        }
    }
}
