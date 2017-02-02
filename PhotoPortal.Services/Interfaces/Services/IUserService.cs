using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhotoPortal.DomainEntities.Entities;

namespace PhotoPortal.Services.Interfaces.Services
{
    public interface IUserService
    {
        User Get(int id);
    }
}