using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Infrastructure
{
    public interface IMessagingService
    {
        void SendMessage(Guid id);
        void SendMessageToAll();
    }
}
