using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Commands
{
    public class CommandFactory
    {
        public static ICommand GetCommandInstance(CommandType type)
        {
            ICommand instance;

            switch (type) {
                case CommandType.GETUSERS: 
                    instance = new GetUsersCommand(); 
                    break;
                case CommandType.SENDMESSAGE: 
                    instance = new SendMessageCommand(); 
                    break;
                default: 
                    instance = null; 
                    break;

            }

            return instance;

        }
    }
}
