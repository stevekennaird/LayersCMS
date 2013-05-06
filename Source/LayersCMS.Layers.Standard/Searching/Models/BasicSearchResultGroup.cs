using System.Collections.Generic;
using LayersCMS.Layers.Core.Search;

namespace LayersCMS.Layers.Standard.Searching.Models
{
    public class BasicSearchResultGroup
    {
        public string Title { get; set; }
        public SearchResultGroupPriority Priority { get; set; }
        public IEnumerable<LayerSearchResult> SearchResults { get; set; }
    }
}
