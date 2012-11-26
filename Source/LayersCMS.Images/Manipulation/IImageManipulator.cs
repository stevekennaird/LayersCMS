using System.Drawing;
using LayersCMS.Data.Domain.Core.Media;

namespace LayersCMS.Images.Manipulation
{
    public interface IImageManipulator
    {
        Image GetImage(LayersCmsImage imageData, ImageResizeDetails resizeDetails);
    }
}