using System.IO;
using ImageResizer;
using LayersCMS.Data.Domain.Core.Media;
using LayersCMS.Data.Persistence.Interfaces.Reads;
using LayersCMS.Images.Storage;
using System;
using System.Drawing;

namespace LayersCMS.Images.Manipulation.Implementations
{
    /// <summary>
    /// Uses http://nuget.org/packages/ImageResizer to handle image resizing
    /// </summary>
    public class ImageResizerManipulator : StandardImageManipulator
    {
        #region Constants

        // The quality level to render normal size images
        private const int StandardImageQualityPercent = 90;

        // The quality level to render small images
        private const int SmallImageQualityPercent = 100;

        // The maximum width for a 'small' image
        private const int SmallImageThreshold = 100;

        // The type of image file to render - jpg (standard), png, gif etc
        private const string ImageFileExtension = "jpg";


        #endregion

        public ImageResizerManipulator(IImageStore imageStore, ILayersCmsImageReads imageReads) : base(imageStore, imageReads) {}

        public override Image GetImage(LayersCmsImage imageData, ImageResizeDetails resizeDetails)
        {
            if (imageData == null) throw new ArgumentNullException("imageData");
            if (resizeDetails == null) throw new ArgumentNullException("resizeDetails");

            var settings = new ResizeSettings() {Format = ImageFileExtension};

            // If a height AND a width have been specified, resize to the exact width/height combo
            if (resizeDetails.Height != null && resizeDetails.Width != null)
            {
                settings.Height = resizeDetails.Height.Value;
                settings.Width = resizeDetails.Width.Value;
                settings.Mode = FitMode.Crop;

                // If the image is small, use 100% quality, else 90%
                settings.Quality = (resizeDetails.Height.Value <= SmallImageThreshold && resizeDetails.Width.Value <= SmallImageThreshold
                                        ? SmallImageQualityPercent
                                        : StandardImageQualityPercent);
            }
            else if (resizeDetails.Height != null)
            {
                // Only a height has been specified. Proportionally resize the image scaled to the height value
                settings.Height = resizeDetails.Height.Value;
            }
            else if (resizeDetails.Width != null)
            {
                // Only a width has been specified. Proportionally resize the image scaled to the width value
                settings.Width = resizeDetails.Width.Value;
            }

            using (ImageRetrieveResult retrievedImage = ImageStore.RetrieveImage(imageData))
            {
                if (retrievedImage.Successful && retrievedImage.Image != null)
                {
                    // Instantiate a new stream to store the resized image into
                    using (Stream imageStream = new MemoryStream())
                    {
                        // Let ImageResizer handle the resizing
                        ImageBuilder.Current.Build(retrievedImage.Image, imageStream, settings, true);

                        // Return an Image constructed from the stream
                        return Image.FromStream(imageStream);   
                    }
                }

                // If the image data is invalid (no image found), return null
                return null;
            }
        }
    }
}
