using DAL;
using Ninject;
using System;
using System.Collections.Generic;
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