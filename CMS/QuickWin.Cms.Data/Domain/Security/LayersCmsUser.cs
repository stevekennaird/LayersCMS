using System;
using ServiceStack.DataAnnotations;

namespace LayersCMS.Data.Domain.Security
{
    public class LayersCmsUser : LayersCmsDomainObject
    {
        [Index(Unique = true)]
        public virtual String EmailAddress { get; set; }
        
        public virtual String Password { get; set; }

        [Index]
        public virtual Boolean Active { get; set; }
    }
}
