using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Belot.Backend.Services;
using Belot.WebApi.Controllers;
using Microsoft.Practices.Unity;

namespace Belot.WebApi.App_Start
{
    public class ServiceResolver : IDependencyResolver
    {
        public ServiceResolver()
            : this(Initialize())
        {
        }

        public ServiceResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.Container = container;
        }

        public IUnityContainer Container { get; private set; }

        #region IDependencyResolver members

        public object GetService(Type serviceType)
        {
            try
            {
                return Container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return Container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = Container.CreateChildContainer();
            return new ServiceResolver(child);
        }

        public void Dispose()
        {
            Container.Dispose();
        }

        #endregion

        private static IUnityContainer Initialize()
        {
            var container = new UnityContainer();

            container.RegisterType<GameService>(new HierarchicalLifetimeManager());
            container.RegisterType<GameValidationService>(new HierarchicalLifetimeManager());
            container.RegisterType<RoomService>(new HierarchicalLifetimeManager());

            container.RegisterType<GameController>(new HierarchicalLifetimeManager());
            container.RegisterType<RoomController>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}