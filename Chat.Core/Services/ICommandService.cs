using Chat.Core.Commands;
using Chat.Core.Data;
using Chat.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Core.Services
{
    public class Response {
        public IEnumerable<User> Users { get; set; }
        public string PublicContent { get; set; }
        public string PrivateContent { get; set; }
    }

    public interface ICommandService
    {
        void Execute<TCommand>(TCommand command) where TCommand: ICommand;
        void AddSubscriber(string sender, AutoResetEvent e);       
        Response GetResponse(string name);
    }

    public class CommandService : ICommandService
    {
    
        private static Hashtable _events = new Hashtable();
        private static Hashtable _responses = new Hashtable();
        private readonly IUserRepository _repository;
        private ICommandHandlerFactory _factory; 

        public CommandService(ICommandHandlerFactory factory, IUserRepository repository)
        {
            _factory = factory;
            _repository = repository;
        
        }

        public void Execute<TCommand>(TCommand command) where TCommand: ICommand
        {            
            var commandHandler = _factory.Create<TCommand>();
            var response = commandHandler.Handle(command);

            if (command.Receiver == null)
            {
                foreach (DictionaryEntry e in _events)
                {
                    _responses[e.Key] = response;
                    Notify((string)e.Key);
                }
            }
            else
            {
                _responses[command.Receiver] = response;
                Notify(command.Receiver);
            }

        }

        private void Notify(string name)
        {           
            ((AutoResetEvent)_events[name]).Set();
        }

        public Response GetResponse(string name) 
        {
            try
            {
                return (Response)_responses[name];
            }
            finally 
            {
                RemoveSubscriber(name);
            }
        }

        public void AddSubscriber(string sender, AutoResetEvent e)
        {
            _events.Add(sender, e);
            _responses.Add(sender, new Response());
        }

        private void RemoveSubscriber(string sender)
        {
            _events.Remove(sender);
            _responses.Remove(sender);
        }
    
    }
}
