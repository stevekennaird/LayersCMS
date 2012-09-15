using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace QuickWin.MvcApplication.Controllers
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

    }
}
