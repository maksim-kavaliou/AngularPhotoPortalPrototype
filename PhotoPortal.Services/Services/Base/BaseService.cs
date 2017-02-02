using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhotoPortal.DataAccess.Interfaces.Factories;

namespace PhotoPortal.Services.Services.Base
{
    public abstract class BaseService
    {
        protected BaseService(IRepositoryFactory repositories)
        {
            this.Repositories = repositories;
        }

        protected IRepositoryFactory Repositories { get; }
    }
}