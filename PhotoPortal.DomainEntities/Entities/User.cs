using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhotoPortal.DomainEntities.Entities.Base;

namespace PhotoPortal.DomainEntities.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}