using System.Collections.Generic;
using PhotoPortal.DomainEntities.Entities.Base;

namespace PhotoPortal.DataAccess.Interfaces.Repositories.Base
{
    public interface IEntityRepository<T> where T : BaseEntity
    {
        T Get(int id);

        IList<T> GetListByParameters(IList<string> parametersList = null, object param = null,
            string parametersSeparator = "AND");

        int Create(T entity);

        void Update(T entity);
    }
}
