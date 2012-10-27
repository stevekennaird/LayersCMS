using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace LayersCMS.Data.Domain.Core.Security
{
    public class LayersCmsUser : LayersCmsDomainObject
    {
        [Index(Unique = true), Required, StringLength(250)]
        public virtual String EmailAddress { get; set; }
        
        [Required, StringLength(50)]
        public virtual String Password { get; set; }

        [Index]
        public virtual Boolean Active { get; set; }
    }
}
