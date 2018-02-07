using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PhotoPortal.Services.Interfaces.Factories;
using PhotoPortal.Web.Controllers.Base;
using PhotoPortal.WebCore.Models;

namespace PhotoPortal.Web.Controllers
{
    public class PhotoController : BaseController
    {
        public PhotoController(IServiceFactory services) : base(services)
        {
        }

        // GET: Images
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Upload(HttpPostedFileBase photo)
        {
            if (photo != null)
            {
                var photoId = await Services.PhotoService.Save(photo.InputStream);

                return RedirectToAction("Show", new {id = photoId});
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult Show(string id)
        {
            var model = new PhotoModel() {Uri = Services.PhotoService.UriFor(id).ToString()};

            return View(model);
        }
    }
}