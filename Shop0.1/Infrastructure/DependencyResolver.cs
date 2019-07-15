using DAL;
using DAL.Abstract;
using DAL.Concrete;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop0._1.Infrastructure
{
    public class MyDependencyResolver : IDependencyResolver
    {
        IKernel kernel;
        public MyDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        private void AddBindings()
        {
            kernel.Bind<IGoodRepository>().To<GoodRepository>();            //Model
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                .AppSettings["Email.WriteAsFile"] ?? "false")
            };
            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
            .WithConstructorArgument("settings", emailSettings);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}