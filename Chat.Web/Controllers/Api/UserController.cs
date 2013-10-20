using Chat.Core.Data;
using Chat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Chat.Controllers.Api
{
    public class UserController : ApiController
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [AcceptVerbs("GET")]
        public HttpResponseMessage GetUsers()
        {
            var users = _repository.GetUsers();
            var json = JsonConvert.SerializeObject(users);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json)
            };
        }

        [AcceptVerbs("POST")]
        public HttpResponseMessage AddUser(User user)
        {
            _repository.AddUser(user);            

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
