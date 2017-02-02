using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhotoPortal.DataAccess.Interfaces.Repositories;
using PhotoPortal.DataAccess.Repositories.Base;
using PhotoPortal.DomainEntities.Entities;

namespace PhotoPortal.DataAccess.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public User Get(int id)
        {
            return new User { Id = 1, Name = "test" };
        }
    }
}