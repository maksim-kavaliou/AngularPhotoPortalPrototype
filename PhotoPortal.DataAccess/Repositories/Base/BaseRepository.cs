using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhotoPortal.Infrastructure.Interfaces;

namespace PhotoPortal.DataAccess.Repositories.Base
{
    public abstract class BaseRepository
    {
        protected readonly string ConnectionString;

        protected BaseRepository(IConfigurationManager configurationManager)
        {
            this.ConnectionString = configurationManager.ConnectionString;
        }
    }
}