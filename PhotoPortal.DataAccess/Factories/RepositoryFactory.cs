using System;

using Microsoft.Practices.Unity;

using PhotoPortal.DataAccess.Interfaces.Factories;
using PhotoPortal.DataAccess.Interfaces.Repositories;

namespace PhotoPortal.DataAccess.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IUnityContainer container;

        public RepositoryFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public IUserRepository UserRepository
        {
            get
            {
                return this.GetRepository<IUserRepository>().Value;
            }
        }

        private Lazy<T> GetRepository<T>()
        {
            return new Lazy<T>(() => this.container.Resolve<T>());
        }
    }
}