using PhotoPortal.DataAccess.Interfaces.Repositories.Base;
using PhotoPortal.DomainEntities.Entities;

namespace PhotoPortal.DataAccess.Interfaces.Repositories
{
    public interface IPhotoRepository : IEntityRepository<Photo>
    {
    }
}
