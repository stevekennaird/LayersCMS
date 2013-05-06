using System;
using System.ComponentModel.DataAnnotations;

namespace LayersCMS.Web.Validation
{
    /// <summary>
    /// Validates that a string is a valid relative url, e.g. '/' or '/home' but not 'http://www.test.com' or 'home' or '/home/'.
    /// Warning: null or empty string values are classed as valid. Use the <see cref="RequiredAttribute"/> to combat this.
    /// </summary>
    public class RelativeUrlAttribute : ValidationAttribute
    {
        public RelativeUrlAttribute()
        {
            ErrorMessage = "Please enter a valid url";
        }

        public override bool IsValid(object value)
        {
            // If the value is null, return true. Use RequiredAttribute to overcome this.
            if (value == null) return true;

            string url = value.ToString();

            // If the string value is null or an empty string, return true. Use RequiredAttribute to overcome this.
            if (string.IsNullOrEmpty(url)) return true;

            return url == "/" || (url.StartsWith("/") && Uri.IsWellFormedUriString(url, UriKind.Relative) && !url.EndsWith("/"));
        }
    }
}