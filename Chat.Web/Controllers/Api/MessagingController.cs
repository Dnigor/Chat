using Chat.Core.Entities;
using Chat.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chat.Controllers.Api
{
    public class MessagingController : ApiController
    {
        private readonly IMessagingService _messagingService;

        public MessagingController(IMessagingService messagingService)
        {
            _messagingService = messagingService;
        }

        [AcceptVerbs("POST")]
        public HttpResponseMessage SendMessage(Message message)
        {
            _messagingService.SendMessage(message);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
