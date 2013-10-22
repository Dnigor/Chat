using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Chat.Core.Data;
using Chat.Core.Services;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Chat.App_Start
{
    public class ContainerConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new AutofacWebTypesModule());
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<CacheRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<PollingService>().As<IPollingService>();
            builder.RegisterType<MessagingService>().As<IMessagingService>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));            
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
        }
    }
}