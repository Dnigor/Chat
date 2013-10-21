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
    public class Status
    {
        public string Message { get; set; }
    }

    public interface IPollingService
    {
        IEnumerable<User> GetStatus();
    }

    public class PollingService : IPollingService
    {
        private readonly IUserRepository _repository;
        private AutoResetEvent _event;

        public PollingService(IUserRepository repository)
        {
            _repository = repository;
            _event = new AutoResetEvent(false);
            _repository.OnChanged += OnChanged;
        }

        public IEnumerable<User> GetStatus() 
        {
            try
            {
                _event.WaitOne();
            }
            finally 
            {
                _event.Reset();
            }
            return _repository.GetUsers();
        }

        public void OnChanged()
        {
            _event.Set();
        }

    }
}
