using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace LayersCMS.Data.Domain.Core.Media
{
    public class LayersCmsImage : LayersCmsDomainObject
    {
        [Required, StringLength(100), Index(Unique = true)]
        public virtual String Filename { get; set; }

        [Required, StringLength(100)]
        public virtual String AltText { get; set; }

        [Required, StringLength(150), Index(Unique = true)]
        public virtual String UrlFilename { get; set; }

        [Required]
        public virtual Int32 Width { get; set; }

        [Required]
        public virtual Int32 Height { get; set; }
    }
}
