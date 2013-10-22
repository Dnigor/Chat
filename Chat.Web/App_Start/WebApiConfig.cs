using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Chat
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "UsersApi",
                routeTemplate: "api/user/{action}",
                defaults: new { controller = "user" }
            );

            //config.Routes.MapHttpRoute(
            //    name: "PollApi",
            //    routeTemplate: "api/poll/{id}",
            //    defaults: new { controller = "poll" }
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
