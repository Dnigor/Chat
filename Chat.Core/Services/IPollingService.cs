using Chat.Core.Data;
using Chat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Core.Services
{

    public interface IPollingService
    {
        dynamic Get(string name);     
    }

    public class PollingService : IPollingService
    {    
        private readonly ICommandService _commandService;
        private readonly AutoResetEvent _event = new AutoResetEvent(false);

        public PollingService(ICommandService commandService)
        {                     
            _commandService = commandService;          
        }

        public dynamic Get(string name) 
        {           
           _commandService.AddSubscriber(name, _event);
           _event.WaitOne();                 
            var response = _commandService.GetResponse(name);
            return response;
        }


    }
}
