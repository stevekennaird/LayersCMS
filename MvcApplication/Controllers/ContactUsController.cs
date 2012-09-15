using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using QuickWin.MvcApplication.Models.ContactUs;

namespace QuickWin.MvcApplication.Controllers
{
    public class ContactUsController : Controller
    {
        [GET("contact")]
        public ActionResult BasicForm()
        {
            return View();
        }

        [POST("contact")]
        public ActionResult BasicForm(ContactUsModel model)
        {
            if (ModelState.IsValid)
            {
                
            }

            return View();
        }

    }
}
