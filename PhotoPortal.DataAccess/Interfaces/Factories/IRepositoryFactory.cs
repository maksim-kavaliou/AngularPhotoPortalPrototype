using PhotoPortal.DataAccess.Interfaces.Repositories;

namespace PhotoPortal.DataAccess.Interfaces.Factories
{
    public interface IRepositoryFactory
    {
        IUserRepository UserRepository { get; }
    }
}