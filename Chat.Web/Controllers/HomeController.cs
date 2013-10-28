using Chat.Core.Data;
using Chat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _repository;

        public HomeController(IUserRepository repository)
        {
            _repository = repository;
        }


        public ActionResult Register()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _repository.AddUser(user);
                return View("Chat", user);
            }

            return View("Error");
        }

       

    }
}
