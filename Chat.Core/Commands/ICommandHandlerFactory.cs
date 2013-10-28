using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Commands
{
    public interface ICommandHandlerFactory 
    {
        ICommandHandler<TCommand> Create<TCommand>();
    }

    public class CommandHandlerFactory: ICommandHandlerFactory
    {
        private readonly IComponentContext _componentContext;

        public CommandHandlerFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public ICommandHandler<TCommand> Create<TCommand>()
        {
            return _componentContext.Resolve<ICommandHandler<TCommand>>();
        }
    }
}
