using LayersCMS.Data.Domain.Core.Media;
using System;

namespace LayersCMS.Images.Storage
{
    public class ImageSaveResult
    {
        public virtual Boolean Successful { get; set; }
        public virtual String ErrorMessage { get; set; }
        public virtual Exception Exception { get; set; }
        public virtual LayersCmsImage CmsImage { get; set; }
    }
}
