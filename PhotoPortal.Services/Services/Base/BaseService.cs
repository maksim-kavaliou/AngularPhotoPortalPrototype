using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhotoPortal.DataAccess.Interfaces.Factories;
using PhotoPortal.Services.Interfaces.Factories;

namespace PhotoPortal.Services.Services.Base
{
    public abstract class BaseService
    {
        protected BaseService(IRepositoryFactory repositories, IServiceFactory services)
        {
            this.Repositories = repositories;
            this.Services = services;
        }

        protected IRepositoryFactory Repositories { get; }

        protected IServiceFactory Services { get; }
    }
}