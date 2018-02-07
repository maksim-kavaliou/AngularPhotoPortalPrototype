using System;
using PhotoPortal.DataAccess.Interfaces.Repositories;

namespace PhotoPortal.DataAccess.Interfaces.Factories
{
    public interface IRepositoryFactory
    {
        Lazy<T> GetRepository<T>();

        IUserRepository UserRepository { get; }

        IPhotoRepository PhotoRepository { get; }
    }
}