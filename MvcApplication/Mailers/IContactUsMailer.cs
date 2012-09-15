using System;
using System.Net.Mail;

namespace QuickWin.MvcApplication.Mailers
{ 
    public interface IContactUsMailer
    {
				
		MailMessage BasicFormEmail(String firstName, String lastName, String emailAddress, String telephone, String message);
		
		
	}
}