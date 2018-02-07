using PhotoPortal.DataAccess.Interfaces.Repositories;
using PhotoPortal.DataAccess.Repositories.Base;
using PhotoPortal.DomainEntities.Entities;
using PhotoPortal.Infrastructure.Interfaces;

namespace PhotoPortal.DataAccess.Repositories
{
    public class PhotoRepository : EntityRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(IConfigurationManager configurationManager) : base(configurationManager, "Photo")
        {
        }
    }
}
