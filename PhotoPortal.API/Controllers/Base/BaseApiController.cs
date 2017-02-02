using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using PhotoPortal.Services.Interfaces.Factories;

namespace PhotoPortal.API.Controllers.Base
{
    public abstract class BaseApiController : ApiController
    {
        protected BaseApiController(IServiceFactory services)
        {
            this.Services = services;
        }

        protected IServiceFactory Services { get; }
    }
}