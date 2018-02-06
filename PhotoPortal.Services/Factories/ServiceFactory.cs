using System;
using PhotoPortal.Services.Interfaces.Factories;
using PhotoPortal.Services.Interfaces.Services;
using Unity;

namespace PhotoPortal.Services.Factories
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly IUnityContainer _container;

        public ServiceFactory(IUnityContainer container)
        {
            this._container = container;
        }

        public IUserService UserService => this.GetService<IUserService>().Value;

        public IEncryptionService EncryptionService => this.GetService<IEncryptionService>().Value;

        public IAuthenticationService AuthenticationService => this.GetService<IAuthenticationService>().Value;

        private Lazy<T> GetService<T>()
        {
            return new Lazy<T>(() => this._container.Resolve<T>());
        }
    }
}