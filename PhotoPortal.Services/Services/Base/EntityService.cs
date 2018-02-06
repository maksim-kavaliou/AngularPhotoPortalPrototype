using System.Collections.Generic;
using PhotoPortal.DataAccess.Interfaces.Factories;
using PhotoPortal.DataAccess.Interfaces.Repositories.Base;
using PhotoPortal.DomainEntities.Entities.Base;
using PhotoPortal.Services.Interfaces.Factories;
using PhotoPortal.Services.Interfaces.Services.Base;

namespace PhotoPortal.Services.Services.Base
{
    public class EntityService<T, TR> : BaseService, IEntityService<T>
        where T : BaseEntity
        where TR: IEntityRepository<T>

    {
        public EntityService(IRepositoryFactory repositories, IServiceFactory services) : base(repositories, services)
        {
            Repository = repositories.GetRepository<TR>().Value;
        }

        protected TR Repository { get; }

        public T Get(int id)
        {
            return Repository.Get(id);
        }

        public IList<T> GetListByParameters(IList<string> parametersList = null, object param = null, string parametersSeparator = "AND")
        {
            var result = Repository.GetListByParameters(parametersList, param, parametersSeparator);

            return result;
        }
    }
}
