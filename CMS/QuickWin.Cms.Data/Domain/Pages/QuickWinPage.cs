using System;
using ServiceStack.DataAnnotations;

namespace QuickWin.Cms.Data.Domain.Pages
{
    public class QuickWinPage : QuickWinDomainObject
    {
        public virtual Int32? ParentId { get; set; }

        public virtual String WindowTitle { get; set; }

        public virtual String MetaDescription { get; set; }

        public virtual String MetaKeywords { get; set; }

        [Index(Unique = true)]
        public virtual String Url { get; set; }

        public virtual String Content { get; set; }

        public virtual DateTime? PublishStart { get; set; }

        public virtual DateTime? PublishEnd { get; set; }

        public virtual String RedirectUrl { get; set; }

        public virtual RedirectTypeEnum RedirectType { get; set; }
    }
}
