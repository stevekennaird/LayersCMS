using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace LayersCMS.MvcApp.Controllers
{
    public class HomeController : Controller
    {
        [GET("/")]
        public ActionResult Index()
        {
            return View();
        }

        [GET("about")]
        public ActionResult About()
        {
            return View();
        }

        [GET("gallery")]
        public ActionResult Gallery()
        {
            return View();
        }

    }
}
