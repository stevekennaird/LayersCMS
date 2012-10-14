using LayersCMS.Data.Domain.Pages;

namespace LayersCMS.Data.Persistence.Interfaces.Writes.Base
{
    public interface ILayersCmsPageWrites : ILayersCmsWrites<LayersCmsPage>
    {
        LayersCmsPage Update(int id);
    }
}