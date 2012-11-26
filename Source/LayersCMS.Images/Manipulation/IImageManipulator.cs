using System;
using System.Drawing;
using LayersCMS.Data.Domain.Core.Media;
using LayersCMS.Images.Storage;

namespace LayersCMS.Images.Manipulation
{
    /// <summary>
    /// Rules that define a class to use to handle image resizing
    /// </summary>
    public interface IImageManipulator
    {
        /// <summary>
        /// Retrieve an <see cref="Image"/> from the <see cref="IImageStore"/> implementation given the image data and resize details
        /// </summary>
        /// <param name="imageData">The domain object to return an image for</param>
        /// <param name="resizeDetails">The details that will determine the size of the generated file</param>
        Image GetImage(LayersCmsImage imageData, ImageResizeDetails resizeDetails);

        /// <summary>
        /// Retrieve an <see cref="Image"/> from the <see cref="IImageStore"/> implementation given the image data and resize details
        /// </summary>
        /// <param name="imageId">The Id of the domain object to return an image for</param>
        /// <param name="resizeDetails">The details that will determine the size of the generated file</param>
        Image GetImage(Int32 imageId, ImageResizeDetails resizeDetails);
    }
}