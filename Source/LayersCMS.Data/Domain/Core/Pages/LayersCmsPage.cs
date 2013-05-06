using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace LayersCMS.Data.Domain.Core.Pages
{
    public class LayersCmsPage : LayersCmsDomainObject
    {
        [Index]
        public virtual Int32? ParentId { get; set; }

        [Required, StringLength(75)]
        public virtual String WindowTitle { get; set; }

        [StringLength(160)]
        public virtual String MetaDescription { get; set; }

        [StringLength(250)]
        public virtual String MetaKeywords { get; set; }

        [Required, StringLength(50)]
        public virtual String DisplayName { get; set; }

        [Index(Unique = true), Required, StringLength(250)]
        public virtual String Url { get; set; }

        [Required, StringLength(250)]
        public virtual String PageTitle { get; set; }

        [Required, StringLength(10000)] /* HOW TO GET ORMLITE TO WORK WITH NVARCHAR(MAX)?! */
        public virtual String Content { get; set; }

        [StringLength(4000)]
        public virtual String CustomScripts { get; set; }

        [Index]
        public virtual DateTime? PublishStart { get; set; }

        [Index]
        public virtual DateTime? PublishEnd { get; set; }

        [StringLength(250)]
        public virtual String RedirectUrl { get; set; }

        public virtual Int32? RedirectType { get; set; }

        [Index]
        public virtual Boolean Active { get; set; }

        [Index]
        public virtual Boolean ShowInNavigation { get; set; }

        [Index]
        public virtual Int32 SortOrder { get; set; }


        [Ignore]
        public virtual RedirectTypeEnum RedirectTypeEnum
        {
            get { return (RedirectTypeEnum) RedirectType.GetValueOrDefault(0); }
            set { RedirectType = (int) value; }
        }

        /// <summary>
        /// Calculates whether the page should be published, using the PublishStart and PublishEnd dates
        /// </summary>
        [Ignore]
        public virtual Boolean IsPublished
        {
            get
            {
                return Active 
                        &&
                        (PublishStart.HasValue && PublishStart.Value <= DateTime.Now)
                        &&
                       (!PublishEnd.HasValue || DateTime.Now <= PublishEnd.Value);
            }
        }

    }
}
