using System.Linq;
using System.Web.Mvc;
using PhotoPortal.Services.Interfaces.Factories;
using PhotoPortal.Web.Controllers.Base;

namespace PhotoPortal.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IServiceFactory services) : base(services)
        {
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var users = Services.UserService.GetListByParameters().ToList();

            return View(users);
        }

        
    }
}
