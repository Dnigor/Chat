using Chat.Core.Commands;
using Chat.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chat.Controllers.Api
{
    public class CommandsController : ApiController
    {
        private readonly ICommandService _commandService;

        public CommandsController(ICommandService commandService)
        {
            _commandService = commandService;
        }

        [AcceptVerbs("POST")]
        public void GetUsers(CommandRequest cmd)
        {
            var command = new GetUsersCommand()
            {
                Sender = cmd.Sender,
                Receiver = cmd.Receiver
            };             
            _commandService.Execute<GetUsersCommand>(command);
        }

        [AcceptVerbs("POST")]
        public void SendMessage(CommandRequest cmd)
        {
            var command = new SendMessageCommand()
            {
                Sender = cmd.Sender,
                Receiver = cmd.Receiver,
                Content = cmd.Content
            };
            _commandService.Execute<SendMessageCommand>(command);
        }
    }

    public class CommandRequest
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }     
        public string Content { get; set; }
    }
}
