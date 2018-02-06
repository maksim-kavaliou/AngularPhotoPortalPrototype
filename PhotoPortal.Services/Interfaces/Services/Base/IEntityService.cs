using PhotoPortal.DomainEntities.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoPortal.Services.Interfaces.Services.Base
{
    public interface IEntityService <T> where T : BaseEntity
    {
        T Get(int id);

        IList<T> GetListByParameters(IList<string> parametersList = null, object param = null,
            string parametersSeparator = "AND");
    }
}
