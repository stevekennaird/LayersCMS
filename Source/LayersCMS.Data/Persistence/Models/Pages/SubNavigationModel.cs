using System.Collections.Generic;
using LayersCMS.Data.Domain.Core.Pages;

namespace LayersCMS.Data.Persistence.Models.Pages
{
    public class SubNavigationModel
    {
        public LayersCmsPage ParentPage { get; set; }
        public IEnumerable<NavigationPageDetails> ChildPages { get; set; }
    }
}
