using System;
using System.Drawing;
using LayersCMS.Data.Domain.Core.Media;

namespace LayersCMS.Images.Storage
{
    /// <summary>
    /// A storage medium for image files. Could be a simple file store, BLOB store etc.
    /// </summary>
    public interface IImageStore
    {
        /// <summary>
        /// Save an image down to the persistence medium
        /// </summary>
        /// <param name="graphic">The image in memory to save down to a file</param>
        /// <param name="imageData">The <see cref="LayersCmsImage"/> instance containing the data required to save the file down as</param>
        /// <param name="disposeOnComplete">Whether or not to dispose of the graphic in memory once the file has been saved</param>
        ImageSaveResult SaveImage(Image graphic, LayersCmsImage imageData, Boolean disposeOnComplete);

        /// <summary>
        /// Attempt to retrieve an image from the storage medium
        /// </summary>
        /// <param name="image">The <see cref="LayersCmsImage"/> instance containing the data required to retrieve an <see cref="Image"/> for</param>
        ImageRetrieveResult RetrieveImage(LayersCmsImage image);
    }
}