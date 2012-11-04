using System;
using System.Linq.Expressions;
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


        /// <summary>
        /// Returns either "Yes" or "No" after calculating the boolean value for an object.
        /// If a boolean value cannot be determined, "-" is returned.
        /// </summary>
        public static String FriendlyBoolean(this HtmlHelper helper, Object value)
        {
            if (value == null)
                return "-";

            var val = value.ToString();
            if (!string.IsNullOrEmpty(val))
            {
                val = val.ToLower();
                if (val == "true" || val == "yes" || val == "1")
                    return "Yes";
            }

            return "No";
        }

        /// <summary>
        /// Create a text input element for a model property, adding the necessary classes to turn the input into a datepicker
        /// </summary>
        public static MvcHtmlString CalendarFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string dateFormat = "dd/MM/yyyy")
        {
            string value = string.Empty;
            var memberExpression = expression.Body as MemberExpression;

            if (htmlHelper.ViewData.Model != null)
            {
                var prop = expression.Compile().Invoke(htmlHelper.ViewData.Model);
                value = prop == null ? string.Empty : prop.ToString();
            }
            DateTime outputDate;
            if (DateTime.TryParse(value, out outputDate))
                value = outputDate.ToString(dateFormat);
            else
                value = "";

            //string propertyName = memberExpression.Member.Name;
            var sb = new StringBuilder("<div class=\"input-append date datepicker\">");
            sb.AppendFormat("<input type=\"text\" class=\"input-medium\" id=\"{0}\" name=\"{0}\" value=\"{1}\" />", memberExpression.Member.Name, value);
            sb.AppendFormat("<span class=\"add-on\"><i class=\"icon-calendar\"></i></span></div>");
            return new MvcHtmlString(sb.ToString());
        }

        /// <summary>
        /// Create a text input element for a model property, adding the necessary classes to turn the input into a timepicker
        /// </summary>
        public static MvcHtmlString TimepickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            string value = string.Empty;
            var memberExpression = expression.Body as MemberExpression;

            if (htmlHelper.ViewData.Model != null)
            {
                var prop = expression.Compile().Invoke(htmlHelper.ViewData.Model);
                value = prop == null ? string.Empty : prop.ToString();
            }

            var sb = new StringBuilder("<div class=\"input-append bootstrap-timepicker-component\">");
            sb.AppendFormat("<input type=\"text\" class=\"timepicker-default input-small\" id=\"{0}\" name=\"{0}\" value=\"{1}\" />", memberExpression.Member.Name, value);
            sb.AppendFormat("<span class=\"add-on\"><i class=\"icon-time\"></i></span></div>");
            return new MvcHtmlString(sb.ToString());
        }

        /// <summary>
        /// Create a standard form help icon with tooltip text
        /// </summary>
        /// <param name="tipText">The help message to display in the tooltip</param>
        public static IHtmlString HelpIcon(this HtmlHelper helper, String tipText)
        {
            var builder = new TagBuilder("i");
            builder.AddCssClass("help-tip");
            builder.AddCssClass("icon-question-sign");
            builder.MergeAttribute("title", tipText);
            
            // Render tag
            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
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