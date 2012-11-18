using System.Web.Mvc;
using AttributeRouting;
using LayersCMS.Data.Domain.Core.Security;
using LayersCMS.Data.Persistence.Interfaces.Reads;

namespace LayersCMS.MvcApp.Areas.Admin.Controllers.Base
{
    [RouteArea("Admin", AreaUrl = "admin"), Authorize]
    public abstract class LayersCmsAdminController : Controller
    {
        private readonly ILayersCmsUserReads _userReads;

        protected LayersCmsAdminController(ILayersCmsUserReads userReads)
        {
            _userReads = userReads;
        }

        private LayersCmsUser _loggedInUser;
        public virtual LayersCmsUser LoggedInUser { 
            get
            {
                if (_loggedInUser == null && User != null)
                {
                    _loggedInUser = _userReads.GetByEmailAddress(User.Identity.Name);   
                }
                return _loggedInUser;
            } 
        }
    }
}
