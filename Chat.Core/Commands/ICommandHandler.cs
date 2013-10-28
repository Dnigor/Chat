using Chat.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Commands
{
    public interface ICommandHandler<TCommand>
    {
        Response Handle(TCommand command);
    }
}
