using System;
using System.Drawing;

namespace LayersCMS.Images.Storage
{
    public class ImageRetrieveResult : IDisposable
    {
        public virtual Boolean Successful { get; set; }
        public virtual Image Image { get; set; }
        public virtual String ErrorMessage { get; set; }
        public virtual Exception Exception { get; set; }
        
        public void Dispose()
        {
            if (Image != null) Image.Dispose();
        }
    }
}
