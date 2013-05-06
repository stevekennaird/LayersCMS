using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using LayersCMS.MvcApp.Models.Galleries;
using LayersCMS.Web.Config;

namespace LayersCMS.MvcApp.Application.Helpers
{
    public static class HtmlHelperExtensions
    {
        #region LayersCMS Configuration Values

        public static IHtmlString LayersCmsConfigCompanyName(this HtmlHelper helper)
        {
            return new MvcHtmlString(new LayersCmsConfigHelper().GetCompanyName());
        }

        public static IHtmlString LayersCmsConfigContactEmailAddress(this HtmlHelper helper)
        {
            return new MvcHtmlString(new LayersCmsConfigHelper().GetContactEmailAddress());
        }

        public static IHtmlString LayersCmsConfigContactPhoneNumber(this HtmlHelper helper)
        {
            return new MvcHtmlString(new LayersCmsConfigHelper().GetContactPhone());
        }

        #endregion

        #region Galleries

        public static IHtmlString NivoGallery(this HtmlHelper helper, params GalleryImage[] images)
        {
            var output = new StringBuilder("<div class=\"nivo nivoGallery\"><ul>");

            foreach (GalleryImage img in images)
            {
                output.AppendFormat("<li data-title=\"{0}\" data-caption=\"{1}\"><img src=\"{2}\" alt=\"\" /></li>", img.Title, img.Caption, img.ImageUrl);
            }

            output.Append("</ul></div>");
            return new MvcHtmlString(output.ToString());
        }

        #endregion

        #region Theme-specific scripts and stylesheets

        public static IHtmlString RenderThemeHeadCustomHtml(this HtmlHelper helper)
        {
            return RenderThemeCustomPartial(helper, @"ThemePartials/{0}Head");
        }

        public static IHtmlString RenderThemeBodyCloseCustomHtml(this HtmlHelper helper)
        {
            return RenderThemeCustomPartial(helper, @"ThemePartials/{0}BodyClose");
        }

        private static IHtmlString RenderThemeCustomPartial(HtmlHelper helper, string viewPathToFormat)
        {
            string themeName = new LayersCmsConfigHelper().GetTheme();
            string viewPath = string.Format(viewPathToFormat, themeName);
            string filePath = HttpContext.Current.Server.MapPath(String.Format("~/views/shared/{0}.cshtml", viewPath));
            if (File.Exists(filePath))
            {
                return helper.Partial(viewPath);
            }
            return null;
        }

        #endregion
    }
}