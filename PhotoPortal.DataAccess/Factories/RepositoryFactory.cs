using System;
using PhotoPortal.DataAccess.Interfaces.Factories;
using PhotoPortal.DataAccess.Interfaces.Repositories;
using Unity;

namespace PhotoPortal.DataAccess.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IUnityContainer _container;

        public RepositoryFactory(IUnityContainer container)
        {
            this._container = container;
        }

        public IUserRepository UserRepository => this.GetRepository<IUserRepository>().Value;

        public Lazy<T> GetRepository<T>()
        {
            return new Lazy<T>(() => this._container.Resolve<T>());
        }
    }
}