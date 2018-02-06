using PhotoPortal.DomainEntities.Entities;
using PhotoPortal.Services.Interfaces.Services.Base;

namespace PhotoPortal.Services.Interfaces.Services
{
    public interface IUserService : IEntityService<User>
    {
        User GetByEmail(string email);

        void Create(User user);
    }
}