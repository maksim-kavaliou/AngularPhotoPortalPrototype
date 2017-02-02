using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhotoPortal.DataAccess.Interfaces.Factories;
using PhotoPortal.DataAccess.Interfaces.Repositories;
using PhotoPortal.DomainEntities.Entities;
using PhotoPortal.Services.Interfaces.Services;
using PhotoPortal.Services.Services.Base;

namespace PhotoPortal.Services.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IRepositoryFactory repositories)
            : base(repositories)
        {
        }

        private IUserRepository Repository
        {
            get
            {
                return this.Repositories.UserRepository;
            }
        }

        public User Get(int id)
        {
            return this.Repository.Get(id);
        }
    }
}