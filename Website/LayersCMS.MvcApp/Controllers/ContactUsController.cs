using System;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using LayersCMS.MvcApp.Mailers;
using LayersCMS.MvcApp.Models.ContactUs;

namespace LayersCMS.MvcApp.Controllers
{
    public class ContactUsController : Controller
    {
        [GET("contact")]
        public ActionResult BasicForm(bool sent = false)
        {
            ViewBag.SendSuccessful = sent;

            var model = new ContactUsModel()
                {
                    DateFormLoaded = DateTime.Now
                };

            return View(model);
        }

        [POST("contact")]
        public ActionResult BasicForm(ContactUsModel model)
        {
            if (ModelState.IsValid)
            {
                IContactUsMailer mailer = new ContactUsMailer();
                mailer.BasicFormEmail(model.FirstName, model.LastName, model.EmailAddress, model.TelephoneNumber, model.Message).Send();

                return RedirectToAction("BasicForm", new {sent = true});
            }

            ViewBag.SendSuccessful = false;
            return View();
        }

    }
}
