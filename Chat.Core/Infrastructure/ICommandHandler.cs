using Chat.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Infrastructure
{
    public interface ICommandHandler<TCommand>
    {
        dynamic Handle(TCommand command);
    }
}
