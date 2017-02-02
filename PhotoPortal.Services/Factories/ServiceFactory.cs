using System;

using Microsoft.Practices.Unity;

using PhotoPortal.DataAccess.Interfaces.Repositories;
using PhotoPortal.Services.Interfaces.Factories;
using PhotoPortal.Services.Interfaces.Services;

namespace PhotoPortal.Services.Factories
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly IUnityContainer container;

        public ServiceFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public IUserService UserService
        {
            get
            {
                return this.GetService<IUserService>().Value;
            }
        }

        private Lazy<T> GetService<T>()
        {
            return new Lazy<T>(() => this.container.Resolve<T>());
        }
    }
}