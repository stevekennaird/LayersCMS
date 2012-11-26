using LayersCMS.Data.Domain.Core.Media;
using LayersCMS.Util.Files;
using System;
using System.Drawing;
using System.IO;

namespace LayersCMS.Images.Storage
{
    public class ImageFileStore : IImageStore
    {
        #region Constructor and Fields

        private readonly string _folderPath;
        private readonly FileHelper _fileHelper;

        public ImageFileStore(String folderPath)
        {
            _folderPath = folderPath;
            _fileHelper = new FileHelper();
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
            if (image == null || image.Filename == null) throw new ArgumentNullException("image");

            try
            {
                // Get the full file path
                String imageFilePath = Path.Combine(_folderPath, image.Filename);

                // Load the contents of the file at the given path into an Image instance
                Image img = Image.FromFile(imageFilePath);

                // Return the successful output
                return new ImageRetrieveResult()
                    {
                        ErrorMessage = null,
                        Exception = null,
                        Image = img,
                        Successful = true
                    };
            }
            catch (Exception e)
            {
                // Report the error
                return new ImageRetrieveResult()
                    {
                        ErrorMessage = "Unable to retrieve image file from the file system",
                        Exception = e,
                        Image = null,
                        Successful = false
                    };
            }
        }

        #endregion

        #region Save methods

        private ImageSaveResult SaveImage(Image graphic, LayersCmsImage imageData)
        {
            if (graphic == null) throw new ArgumentNullException("graphic");
            if (imageData == null || imageData.Filename == null) throw new ArgumentNullException("imageData");

            try
            {
                // Generate a unique filename given the data in the imageData param
                String newFilename = _fileHelper.GenerateUniqueFilename(imageData.Filename, _folderPath, true);

                // Save the image file to the file system
                graphic.Save(newFilename);

                // Update the LayersCmsImage so it the filename property matches the filename of the saved file
                imageData.Filename = newFilename;

                // Return the successful result
                return new ImageSaveResult()
                    {
                        CmsImage = imageData,
                        ErrorMessage = null,
                        Exception = null,
                        Successful = true
                    };
            }
            catch (Exception e)
            {
                // Report the error
                return new ImageSaveResult()
                    {
                        Exception = e,
                        CmsImage = null,
                        ErrorMessage = "Unable to save image file",
                        Successful = false
                    };
            }
        }

        #endregion
    }
}
