using Mvc.Mailer;
using System;
using System.Web;
using QuickWin.MvcApp.Application.Config;

namespace QuickWin.MvcApp.Mailers
{ 
    public class ContactUsMailer : MailerBase, IContactUsMailer     
	{
		public ContactUsMailer(): base()
		{
			MasterName = "_Layout";
		}


        public virtual MvcMailMessage BasicFormEmail(String firstName, String lastName, String emailAddress, String telephone, String message)
		{
            var mailMessage = new MvcMailMessage { Subject = String.Format("Enquiry Received from {0}", HttpContext.Current.Request.ServerVariables["HTTP_HOST"]) };
			mailMessage.To.Add(new QuickWinConfigHelper().GetContactEmailAddress());

            ViewBag.FirstName = firstName;
            ViewBag.LastName = lastName;
            ViewBag.EmailAddress = emailAddress;
            ViewBag.Telephone = telephone;
            ViewBag.Message = message.Replace(Environment.NewLine, "<br />");

			PopulateBody(mailMessage, viewName: "BasicFormEmail");

			return mailMessage;
		}

		
	}
}