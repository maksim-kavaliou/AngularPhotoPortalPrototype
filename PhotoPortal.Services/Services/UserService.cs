using PhotoPortal.DataAccess.Interfaces.Factories;
using PhotoPortal.DataAccess.Interfaces.Repositories;
using PhotoPortal.DomainEntities.Entities;
using PhotoPortal.Services.Interfaces.Factories;
using PhotoPortal.Services.Interfaces.Services;
using PhotoPortal.Services.Services.Base;

namespace PhotoPortal.Services.Services
{
    public class UserService : EntityService<User, IUserRepository>, IUserService
    {
        public UserService(IRepositoryFactory repositories, IServiceFactory services)
            : base(repositories, services)
        {
        }

        public User GetByEmail(string email)
        {
            return Repository.GetByEmail(email);
        }


        public void Create(User user)
        {
            user.Password = Services.EncryptionService.EncryptUserCredantials(user.Email, user.Password);

            Repository.Create(user);
        }
    }
}