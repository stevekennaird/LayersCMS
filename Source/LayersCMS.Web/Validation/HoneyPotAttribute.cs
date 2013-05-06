using System.ComponentModel.DataAnnotations;

namespace LayersCMS.Web.Validation
{
    public class HoneyPotAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value == null || value.ToString() == "";
        }
    }
}