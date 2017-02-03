using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoPortal.Infrastructure.Interfaces
{
    public interface IConfigurationManager
    {
        string ConnectionString { get; }
    }
}
