using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

using PhotoPortal.API.Controllers.Base;
using PhotoPortal.DomainEntities.Entities;
using PhotoPortal.Services.Interfaces.Factories;
using PhotoPortal.WebCore.Extensions;
using PhotoPortal.WebCore.Models;

namespace PhotoPortal.API.Controllers
{
    public class AccountController : BaseApiController
    {
        public AccountController(IServiceFactory services)
            : base(services)
        {
        }

        [HttpPost]
        public object Login([FromBody]LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = Services.AuthenticationService.Authenticate(loginModel.Login, loginModel.Password);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(loginModel.Login, false);

                    return new { success = true };
                }

                return new { success = false };
            }

            return new { success = false, errors = ModelState.CollectErrors() };
        }

        [HttpPost]
        public object SignOut()
        {
            FormsAuthentication.SignOut();

            return new { success = true };
        }

        [HttpPost]
        public object Register([FromBody]RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                                {
                                    Name = registerModel.Name,
                                    Email = registerModel.Email,
                                    Password = registerModel.Password
                                };

                this.Services.UserService.Create(user);

                return new { success = true };
            }

            return new { success = false, errors = ModelState.CollectErrors() };
        }
    }
}