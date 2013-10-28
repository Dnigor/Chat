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
  
        public Response Handle(SendMessageCommand command)
        {
            var response = new Response();
            var content = string.Format("{0}: {1}", command.Sender, command.Content);

            if (command.Receiver == null)
                response.PublicContent = content;
            else 
                response.PrivateContent = content;
            
            return response;
        }
    }
}
