using LayersCMS.Data.Domain.Core.Pages;

namespace LayersCMS.Data.Persistence.Interfaces.Writes.Base
{
    public interface ILayersCmsPageWrites : ILayersCmsWrites<LayersCmsPage>
    {
        LayersCmsPage Update(int id);
    }
}