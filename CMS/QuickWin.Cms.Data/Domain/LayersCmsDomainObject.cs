using System;
using ServiceStack.DataAnnotations;

namespace LayersCMS.Data.Domain
{
    public abstract class LayersCmsDomainObject
    {
        [AutoIncrement]
        public virtual Int32 Id { get; set; }
    }
}
