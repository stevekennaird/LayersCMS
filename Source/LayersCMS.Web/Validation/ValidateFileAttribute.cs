using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LayersCMS.Web.Validation
{
    public class ValidateFileAttribute : ValidationAttribute
    {
        public ValidateFileAttribute(int maxFileSizeMb = 20, params string[] allowedExtensions)
        {
            MaxFileSizeMb = maxFileSizeMb;
            Extensions = allowedExtensions;
        }

        private string[] Extensions { get; set; }

        private int MaxFileSizeMb { get; set; }

        public override bool IsValid(object value)
        {
            int MaxContentLength = 1024 * 1024 * MaxFileSizeMb;

            var file = value as HttpPostedFileBase;

            if (file == null)
                return false;
            else if (!Extensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
            {
                ErrorMessage = "Please upload a file of type: " + string.Join(", ", Extensions);
                return false;
            }
            else if (file.ContentLength > MaxContentLength)
            {
                ErrorMessage = "Your file is too large, maximum allowed size is : " + (MaxContentLength / 1024).ToString() + "MB";
                return false;
            }
            else
                return true;
        }
    }
}
