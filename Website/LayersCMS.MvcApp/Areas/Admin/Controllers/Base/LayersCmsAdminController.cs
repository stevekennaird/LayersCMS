using System.Web.Mvc;
using AttributeRouting;

namespace LayersCMS.MvcApp.Areas.Admin.Controllers.Base
{
    [RouteArea("Admin", AreaUrl = "admin"), Authorize]
    public abstract class LayersCmsAdminController : Controller
    {
        

    }
}
