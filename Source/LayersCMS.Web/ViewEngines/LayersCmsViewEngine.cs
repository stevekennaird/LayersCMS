using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LayersCMS.Web.ViewEngines
{
    public class LayersCmsViewEngine : RazorViewEngine
    {
        public LayersCmsViewEngine()
        {
            SetNormalViewLocations();
            SetAreaViewLocations();
        }

        private void SetNormalViewLocations()
        {
            // Get the standard list of locations
            List<string> newViewLocations = base.ViewLocationFormats.ToList();

            // Add the custom locations
            newViewLocations.Add("~/Views/Layers/Standard/{1}/{0}.cshtml");
            newViewLocations.Add("~/Views/Layers/Standard/{1}/{0}.vbhtml");
            newViewLocations.Add("~/Views/Layers/Custom/{1}/{0}.cshtml");
            newViewLocations.Add("~/Views/Layers/Custom/{1}/{0}.vbhtml");

            // Assign the new list to the view engine
            base.ViewLocationFormats = newViewLocations.ToArray();
        }

        private void SetAreaViewLocations()
        {
            // Get the standard list of locations
            List<string> newViewLocations = base.AreaViewLocationFormats.ToList();

            // Add the custom locations
            newViewLocations.Add("~/Areas/{2}/Views/Layers/Standard/{1}/{0}.cshtml");
            newViewLocations.Add("~/Areas/{2}/Views/Layers/Standard/{1}/{0}.vbhtml");
            newViewLocations.Add("~/Areas/{2}/Views/Layers/Custom/{1}/{0}.cshtml");
            newViewLocations.Add("~/Areas/{2}/Views/Layers/Custom/{1}/{0}.vbhtml");

            // Assign the new list to the view engine
            base.AreaViewLocationFormats = newViewLocations.ToArray();
        }
    }
}
