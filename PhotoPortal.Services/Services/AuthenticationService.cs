using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhotoPortal.DataAccess.Interfaces.Factories;
using PhotoPortal.DomainEntities.Entities;
using PhotoPortal.Services.Interfaces.Factories;
using PhotoPortal.Services.Interfaces.Services;
using PhotoPortal.Services.Services.Base;

namespace PhotoPortal.Services.Services
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        public AuthenticationService(IRepositoryFactory repositories, IServiceFactory services)
            : base(repositories, services)
        {
        }

        public User Authenticate(string email, string password)
        {
            var preparedEmail = email.Trim().ToLowerInvariant();

            var encrypredPassword = Services.EncryptionService.EncryptUserCredantials(preparedEmail, password);

            var user = Repositories.UserRepository.Authenticate(preparedEmail, encrypredPassword);

            return user;
        }
    }
}