using System;
using System.Collections.Generic;
using LayersCMS.Data.Domain.Core.Pages;
using LayersCMS.Data.Persistence.Interfaces.Reads.Base;

namespace LayersCMS.Data.Persistence.Interfaces.Reads
{
    public interface ILayersCmsPageReads : ILayersCmsReads<LayersCmsPage>
    {
        LayersCmsPage GetByUrl(String url);
        IEnumerable<LayersCmsPage> GetCollectionForParent(Int32? parentId);
    }
}