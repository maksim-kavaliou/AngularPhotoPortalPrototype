using PhotoPortal.DomainEntities.Entities.Base;

namespace PhotoPortal.DomainEntities.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}