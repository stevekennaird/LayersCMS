using System;
using System.Collections.Generic;
using LayersCMS.Data.Domain.Core.Pages;
using LayersCMS.Data.Persistence.Interfaces.Reads.Base;
using LayersCMS.Data.Persistence.Models.Pages;

namespace LayersCMS.Data.Persistence.Interfaces.Reads
{
    public interface ILayersCmsPageReads : ILayersCmsReads<LayersCmsPage>
    {
        LayersCmsPage GetByUrl(String url);
        IEnumerable<LayersCmsPage> GetCollectionForParent(Int32? parentId);
        IEnumerable<NavigationPageDetails> GetForNavigation(Int32? parentId);
        Int32 GetMaxSortOrderForParent(Int32? parentId);
    }
}