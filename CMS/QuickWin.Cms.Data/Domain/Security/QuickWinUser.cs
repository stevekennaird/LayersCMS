using System;
using ServiceStack.DataAnnotations;

namespace QuickWin.Cms.Data.Domain.Security
{
    public class QuickWinUser : QuickWinDomainObject
    {
        [Index(Unique = true)]
        public virtual String EmailAddress { get; set; }
        
        public virtual String Password { get; set; }

        [Index]
        public virtual Boolean Active { get; set; }
    }
}
