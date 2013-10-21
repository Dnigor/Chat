using Chat.Core.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chat.Controllers.Api
{
    public class PollController : ApiController
    {
        private readonly IPollingService _pollingService;

        public PollController(IPollingService pollingService)
        {
            _pollingService = pollingService;
        }

        [AcceptVerbs("GET")]
        public HttpResponseMessage Get()
        {
            var data = _pollingService.GetStatus();
            var json = JsonConvert.SerializeObject(data);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json)
            };
        }
    }
}
