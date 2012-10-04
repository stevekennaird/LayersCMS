using System;
using Mvc.Mailer;

namespace QuickWin.MvcApp.Mailers
{ 
    public interface IContactUsMailer
    {
        MvcMailMessage BasicFormEmail(String firstName, String lastName, String emailAddress, String telephone, String message);
	}
}