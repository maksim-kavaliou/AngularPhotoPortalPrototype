using System.Web.Http;

using Microsoft.Practices.Unity;

using PhotoPortal.DataAccess.Factories;
using PhotoPortal.DataAccess.Interfaces.Factories;
using PhotoPortal.DataAccess.Interfaces.Repositories;
using PhotoPortal.DataAccess.Repositories;
using PhotoPortal.Infrastructure.Common;
using PhotoPortal.Infrastructure.Interfaces;
using PhotoPortal.Services.Factories;
using PhotoPortal.Services.Interfaces.Factories;
using PhotoPortal.Services.Interfaces.Services;
using PhotoPortal.Services.Services;

using Unity.WebApi;

namespace PhotoPortal.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // config
            container.RegisterType<IConfigurationManager, CommonConfigurationManager>();

            // repositories
            container.RegisterType<IRepositoryFactory, RepositoryFactory>();
            container.RegisterType<IUserRepository, UserRepository>();

            // services
            container.RegisterType<IServiceFactory, ServiceFactory>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IEncryptionService, EncryptionService>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}