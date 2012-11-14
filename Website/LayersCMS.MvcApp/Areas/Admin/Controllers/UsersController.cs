using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using LayersCMS.Data.Persistence.Interfaces.Reads;
using LayersCMS.MvcApp.Areas.Admin.Controllers.Base;

namespace LayersCMS.MvcApp.Areas.Admin.Controllers
{
    public class UsersController : LayersCmsAdminController
    {
        #region Constructor and Dependencies

        private readonly ILayersCmsUserReads _userReads;

        public UsersController(ILayersCmsUserReads userReads)
        {
            _userReads = userReads;
        }

        #endregion


        [GET("users")]
        public ActionResult List()
        {
            return View(_userReads.GetAll());
        }

        [GET("users/add")]
        public ActionResult Add()
        {
            return View();
        }

        [GET("users/edit/{id}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

    }
}
