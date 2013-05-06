using System.Collections.Generic;

namespace LayersCMS.Layers.Standard.Searching.Models
{
    public class BasicSearchResult
    {
        public string Query { get; set; }

        public IEnumerable<BasicSearchResultGroup> SearchResultGroups { get; set; }
    }
}
