using System;
using System.ComponentModel.DataAnnotations;

namespace LayersCMS.MvcApp.Areas.Admin.Models.Auth
{
    public class CmsPageModel
    {
        public virtual Int32? Id { get; set; }

        public virtual Int32? ParentId { get; set; }

        [Required, StringLength(75), Display(Name = "Window title")]
        public virtual String WindowTitle { get; set; }

        [StringLength(150), Display(Name = "Meta description")]
        public virtual String MetaDescription { get; set; }

        [StringLength(175), Display(Name = "Meta keywords")]
        public virtual String MetaKeywords { get; set; }

        [Required, StringLength(250)]
        public virtual String Url { get; set; }

        [Required, StringLength(250), Display(Name = "Page title")]
        public virtual String PageTitle { get; set; }

        [Required, StringLength(4000), Display(Name = "Page content")]
        public virtual String Content { get; set; }

        [StringLength(4000), Display(Name = "Custom scripts")]
        public virtual String CustomScripts { get; set; }

        [Display(Name = "Publish from")]
        public virtual DateTime? PublishStartDate { get; set; }

        public virtual String PublishStartTime { get; set; }

        [Display(Name = "Publish until")]
        public virtual DateTime? PublishEndDate { get; set; }

        public virtual String PublishEndTime { get; set; }

        [StringLength(250), Display(Name = "Redirect to")]
        public virtual String RedirectUrl { get; set; }

        public virtual Int32? RedirectType { get; set; }

        public virtual Boolean Active { get; set; }


    }
}