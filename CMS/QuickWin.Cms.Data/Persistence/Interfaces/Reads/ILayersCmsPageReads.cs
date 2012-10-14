using LayersCMS.Data.Domain.Pages;
using LayersCMS.Data.Persistence.Interfaces.Reads.Base;

namespace LayersCMS.Data.Persistence.Interfaces.Reads
{
    public interface ILayersCmsPageReads : ILayersCmsReads<LayersCmsPage>
    {
        LayersCmsPage GetByUrl(string url, bool publishedOnly);
    }
}