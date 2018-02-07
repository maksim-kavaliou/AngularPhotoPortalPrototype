using PhotoPortal.DomainEntities.Entities.Base;

namespace PhotoPortal.DomainEntities.Entities
{
    public class Photo : BaseEntity
    {
        public string BlobName { get; set; }
    }
}
