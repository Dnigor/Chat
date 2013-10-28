using Chat.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Commands
{
    public class SendMessageCommandHandler : ICommandHandler<SendMessageCommand>
    {
  
        public dynamic Handle(SendMessageCommand command)
        {
            var content = string.Format("{0}: {1}", command.Sender, command.Content);             
            dynamic response;
            
            if (command.Receiver == null)
                response = new { PublicMessage = content };
            else
                response = new { PrivateMessage = content };
            
            return response;
        }
    }
}
