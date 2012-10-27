using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LayersCMS.MvcApp.Application.Helpers.Admin
{
    public static class AdminHtmlHelperExtensions
    {
        
        /// <summary>
        /// Draws an alert to the page
        /// </summary>
        /// <param name="message">The message to display inside the alert (can be HTML)</param>
        /// <param name="boldMessage">Text to put in bold just before the message</param>
        /// <param name="alertType">Either an option from <see cref="AlertTypes"/> or a custom class name</param>
        public static IHtmlString Alert(this HtmlHelper helper, String message, String boldMessage = null, String alertType = "")
        {
            var sb = new StringBuilder();
            sb.AppendFormat(@"<div class='alert {0}'><button type='button' class='close' data-dismiss='alert'>×</button>", alertType);
            if (!String.IsNullOrWhiteSpace(boldMessage))
                sb.AppendFormat("<strong>{0}</strong> ", boldMessage);
            sb.Append(message);
            return new MvcHtmlString(sb.ToString());
        }
    }

    /// <summary>
    /// A container for the default alert styles
    /// </summary>
    public sealed class AlertTypes
    {
        public static readonly String Warning = "";
        public static readonly String Success = " alert-success";
        public static readonly String Error = " alert-error";
    }
}