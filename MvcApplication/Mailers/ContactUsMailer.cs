using Mvc.Mailer;
using System;
using System.Net.Mail;
using System.Web;
using QuickWin.MvcApplication.Application.Config;

namespace QuickWin.MvcApplication.Mailers
{ 
    public class ContactUsMailer : MailerBase, IContactUsMailer     
	{
		public ContactUsMailer(): base()
		{
			MasterName = "_Layout";
		}


        public virtual MailMessage BasicFormEmail(String firstName, String lastName, String emailAddress, String telephone, String message)
		{
            var mailMessage = new MailMessage { Subject = String.Format("Enquiry Received from {0}", HttpContext.Current.Request.ServerVariables["HTTP_HOST"]) };
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