using LayersCMS.Data.Domain.Core.Media;
using LayersCMS.Data.Persistence.Interfaces.Reads;
using LayersCMS.Images.Storage;
using System;
using System.Drawing;

namespace LayersCMS.Images.Manipulation
{
    public abstract class StandardImageManipulator : IImageManipulator
    {
        #region Constructor and Dependencies

        internal readonly IImageStore ImageStore;
        private readonly ILayersCmsImageReads _imageReads;

        protected StandardImageManipulator(IImageStore imageStore, ILayersCmsImageReads imageReads)
        {
            ImageStore = imageStore;
            _imageReads = imageReads;
        }

        #endregion

        public abstract Image GetImage(LayersCmsImage imageData, ImageResizeDetails resizeDetails);

        public Image GetImage(int imageId, ImageResizeDetails resizeDetails)
        {
            if (resizeDetails == null) throw new ArgumentNullException("resizeDetails");

            // Retrieve the image data from the database
            LayersCmsImage imageData = _imageReads.GetById(imageId);

            // If an image is found by that id, get the resized image, otherwise return null
            return imageData != null ? GetImage(imageData, resizeDetails) : null;
        }
    }
}
