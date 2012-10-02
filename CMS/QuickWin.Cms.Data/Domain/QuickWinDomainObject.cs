using System;
using ServiceStack.DataAnnotations;

namespace QuickWin.Cms.Data.Domain
{
    public abstract class QuickWinDomainObject
    {
        [AutoIncrement]
        public virtual Int32 Id { get; set; }
    }
}
