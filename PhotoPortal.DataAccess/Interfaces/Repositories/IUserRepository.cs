using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhotoPortal.DomainEntities.Entities;

namespace PhotoPortal.DataAccess.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User Get(int id);
    }
}