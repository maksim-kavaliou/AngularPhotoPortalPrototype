using PhotoPortal.DataAccess.Interfaces.Repositories.Base;
using PhotoPortal.DomainEntities.Entities;

namespace PhotoPortal.DataAccess.Interfaces.Repositories
{
    public interface IUserRepository : IEntityRepository<User>
    {
        void Create(User user);

        User GetByEmail(string email);

        User Authenticate(string email, string password);
    }
}