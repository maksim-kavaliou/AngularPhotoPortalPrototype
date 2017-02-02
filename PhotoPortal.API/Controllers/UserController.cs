using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using PhotoPortal.API.Controllers.Base;
using PhotoPortal.DomainEntities.Entities;
using PhotoPortal.Services.Interfaces.Factories;

namespace PhotoPortal.API.Controllers
{
    public class UserController : BaseApiController
    {
        public UserController(IServiceFactory services)
            : base(services)
        {
        }

        // GET: api/User/5
        public User Get(int id)
        {
            var result = this.Services.UserService.Get(id);
            return result;
        }
    }
}