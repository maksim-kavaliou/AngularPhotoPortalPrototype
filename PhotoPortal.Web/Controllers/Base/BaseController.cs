using System.Web.Mvc;
using PhotoPortal.Services.Interfaces.Factories;

namespace PhotoPortal.Web.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        protected BaseController(IServiceFactory services)
        {
            this.Services = services;
        }

        protected IServiceFactory Services { get; }
    }
}

