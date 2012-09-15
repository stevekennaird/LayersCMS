using System.Web;
using System.Web.Mvc;

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
    }
}