using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using QuickWin.MvcApp.Application.Config;
using QuickWin.MvcApp.Models.Galleries;

namespace QuickWin.MvcApp.Application.Helpers
{
    public static class HtmlHelperExtensions
    {
        #region QuickWin Configuration Values

        public static IHtmlString QuickWinConfigCompanyName(this HtmlHelper helper)
        {
            return new MvcHtmlString(new QuickWinConfigHelper().GetCompanyName());
        }

        public static IHtmlString QuickWinConfigContactEmailAddress(this HtmlHelper helper)
        {
            return new MvcHtmlString(new QuickWinConfigHelper().GetContactEmailAddress());
        }

        public static IHtmlString QuickWinConfigContactPhoneNumber(this HtmlHelper helper)
        {
            return new MvcHtmlString(new QuickWinConfigHelper().GetContactPhone());
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
            string themeName = new QuickWinConfigHelper().GetTheme();
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