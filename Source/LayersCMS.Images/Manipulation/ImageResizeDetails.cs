using System;

namespace LayersCMS.Images.Manipulation
{
    public class ImageResizeDetails
    {
        public virtual Int32? Height { get; set; }
        public virtual Int32? Width { get; set; }
        public virtual ImageResizeType ResizeType { get; set; }
    }
}
