using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using LayersCMS.Data.Persistence;
using LayersCMS.Layers.Core.Search;
using LayersCMS.Layers.Standard.Searching.Models;
using LayersCMS.Web.Controllers;

namespace LayersCMS.Layers.Standard.Searching
{
    public class SearchController : BaseController
    {
        #region Constructor and Dependencies

        #endregion

        #region Actions

        public ActionResult BasicSearchResults(string query)
        {
            return View(new BasicSearchResult()
                {
                    Query = query,
                    SearchResultGroups = GetBasicSearchResults(query)
                });
        }

        #endregion

        #region Private Methods

        private IEnumerable<BasicSearchResultGroup> GetBasicSearchResults(string query)
        {
            IEnumerable<ISearchableLayer> searchableLayers = new SearchableLayersHelper().GetSearchableLayers();

            if (searchableLayers.Any())
            {
                using (var dbConn = new LayersCmsDb().GetDbConnection())
                {
                    foreach (ISearchableLayer searchableLayer in searchableLayers)
                    {
                        yield return new BasicSearchResultGroup()
                            {
                                Priority = searchableLayer.Priority,
                                SearchResults = searchableLayer.GetBasicSearchResults(query, dbConn),
                                Title = searchableLayer.Title
                            };
                    }
                }
            }
        }

        #endregion







    }
}
