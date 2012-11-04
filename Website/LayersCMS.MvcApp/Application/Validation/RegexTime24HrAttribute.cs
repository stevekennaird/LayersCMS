using System;
using System.ComponentModel.DataAnnotations;

namespace LayersCMS.MvcApp.Application.Validation
{
    public class RegexTime24HrAttribute : RegularExpressionAttribute
    {
        private const String RegexPattern = @"([01]?[0-9]|2[0-3]):[0-5][0-9]";

        public RegexTime24HrAttribute()
            : base(RegexPattern)
        {
            ErrorMessage = "Invalid time entered";
        }
    }
}