using Chat.Core.Data;
using Chat.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Commands
{
    public class GetUsersCommandHandler: ICommandHandler<GetUsersCommand> 
    {
        private readonly IUserRepository _repository;

        public GetUsersCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Response Handle(GetUsersCommand command)
        {
            var users = _repository.GetUsers();
            var response = new Response()
            {
                Users = users
            };

            return response;
        }
    }
}
