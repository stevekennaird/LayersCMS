using System.Collections.Generic;
using System.Data;

namespace LayersCMS.Layers.Core.Search
{
    /// <summary>
    /// A searchable layer. The Search layer will find all implementations
    /// of this interface to run the search methods on
    /// </summary>
    public interface ISearchableLayer
    {
        string Title { get; }

        SearchResultGroupPriority Priority { get; }

        /// <summary>
        /// Get a collection of search results within this layer.
        /// Nothing especially clever about this search method, just a basic text search.
        /// </summary>
        /// <param name="searchPhrase">The phrase to search by</param>
        IEnumerable<LayerSearchResult> GetBasicSearchResults(string searchPhrase, IDbConnection dbConn);
    }
}