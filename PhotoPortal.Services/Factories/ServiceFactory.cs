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

        public IUserService UserService => this.GetService<IUserService>().Value;

        public IEncryptionService EncryptionService => this.GetService<IEncryptionService>().Value;

        public IAuthenticationService AuthenticationService => this.GetService<IAuthenticationService>().Value;

        private Lazy<T> GetService<T>()
        {
            return new Lazy<T>(() => this.container.Resolve<T>());
        }
    }
}