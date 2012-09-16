using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using QuickWin.MvcApplication.Application.Config;
using QuickWin.MvcApplication.Models.Galleries;

namespace QuickWin.MvcApplication.Application.Helpers
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
            string themeName = new QuickWinConfigHelper().GetTheme();
            string viewPath = string.Format(@"ThemePartials\{0}Head", themeName);
            try
            {
                return helper.Partial(viewPath);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static IHtmlString RenderThemeBodyCloseCustomHtml(this HtmlHelper helper)
        {
            string themeName = new QuickWinConfigHelper().GetTheme();
            string viewPath = string.Format(@"ThemePartials\{0}BodyClose", themeName);
            try
            {
                return helper.Partial(viewPath);
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion
    }
}