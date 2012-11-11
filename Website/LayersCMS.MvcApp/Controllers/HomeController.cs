using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace LayersCMS.MvcApp.Controllers
{
    public class HomeController : Controller
    {

        
        [GET("gallery-demo")]
        public ActionResult Gallery()
        {
            return View();
        }

    }
}
