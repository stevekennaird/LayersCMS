using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace LayersCMS.Data.Domain.Pages
{
    public class LayersCmsPage : LayersCmsDomainObject
    {
        public virtual Int32? ParentId { get; set; }

        [Required, StringLength(75)]
        public virtual String WindowTitle { get; set; }

        [StringLength(150)]
        public virtual String MetaDescription { get; set; }

        [StringLength(175)]
        public virtual String MetaKeywords { get; set; }

        [Index(Unique = true), Required, StringLength(250)]
        public virtual String Url { get; set; }

        [Required, StringLength(4000)]
        public virtual String Content { get; set; }

        [StringLength(4000)]
        public virtual String CustomScripts { get; set; }

        public virtual DateTime? PublishStart { get; set; }

        public virtual DateTime? PublishEnd { get; set; }

        [StringLength(250)]
        public virtual String RedirectUrl { get; set; }

        public virtual Int32 RedirectType { get; set; }




        [Ignore]
        public virtual RedirectTypeEnum RedirectTypeEnum
        {
            get { return (RedirectTypeEnum) RedirectType; }
            set { RedirectType = (int) value; }
        }


    }
}
