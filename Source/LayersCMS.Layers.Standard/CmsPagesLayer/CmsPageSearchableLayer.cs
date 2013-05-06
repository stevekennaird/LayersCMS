using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using LayersCMS.Data.Domain.Core.Pages;
using LayersCMS.Layers.Core.Search;
using ServiceStack.OrmLite;

namespace LayersCMS.Layers.Standard.CmsPagesLayer
{
    public class CmsPageSearchableLayer : ISearchableLayer
    {
        public string Title
        {
            get { return "Pages"; }
        }

        public SearchResultGroupPriority Priority { get { return SearchResultGroupPriority.Highest; } }

        public IEnumerable<LayerSearchResult> GetBasicSearchResults(string searchPhrase, IDbConnection dbConn)
        {
            List<LayersCmsPage> pages = dbConn.Select<LayersCmsPage>(page => (page.PageTitle.Contains(searchPhrase)
                                                                                    ||
                                                                                    page.MetaDescription.Contains(searchPhrase)
                                                                                    ||
                                                                                    page.MetaKeywords.Contains(searchPhrase)
                                                                                    ||
                                                                                    page.WindowTitle.Contains(searchPhrase)
                                                                                    ||
                                                                                    page.Content.Contains(searchPhrase)
                                                                                    ));

            return pages.Where(p => p.IsPublished).Select(p => new LayerSearchResult()
                {
                    Description = p.MetaDescription,
                    ImageUrl = null,
                    Name = p.PageTitle,
                    Url = p.Url
                });
        }
    }
}
