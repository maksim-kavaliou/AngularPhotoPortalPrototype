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
using System;

using Unity;

namespace PhotoPortal.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IConfigurationManager, CommonConfigurationManager>();

            // repositories
            container.RegisterType<IRepositoryFactory, RepositoryFactory>();
            container.RegisterType<IUserRepository, UserRepository>();

            // services
            container.RegisterType<IServiceFactory, ServiceFactory>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IEncryptionService, EncryptionService>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();

            container.Resolve<IServiceFactory>();
        }
    }
}