using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayersCMS.Data.Domain.Core.Media;

namespace LayersCMS.Images.Storage
{
    public class ImageFileStore : IImageStore
    {
        #region Constructor and Fields

        private readonly string _folderPath;

        public ImageFileStore(String folderPath)
        {
            _folderPath = folderPath;
        }

        #endregion

        #region Implementation of IImageStore

        public ImageSaveResult SaveImage(Image graphic, LayersCmsImage imageData, bool disposeOnComplete)
        {
            if (graphic == null) throw new ArgumentNullException("graphic");
            if (imageData == null) throw new ArgumentNullException("imageData");

            ImageSaveResult output = SaveImage(graphic, imageData);
            
            // Dispose of the image (if requested)
            if (disposeOnComplete)
                graphic.Dispose();

            return output;
        }

        public ImageRetrieveResult RetrieveImage(LayersCmsImage image)
        {
            if (image == null) throw new ArgumentNullException("image");

            throw new NotImplementedException();
        }

        #endregion

        #region Save methods

        private ImageSaveResult SaveImage(Image graphic, LayersCmsImage imageData)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
