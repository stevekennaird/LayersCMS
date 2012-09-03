using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using MvcApplication.Models.ContactUs;

namespace MvcApplication.Controllers
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
