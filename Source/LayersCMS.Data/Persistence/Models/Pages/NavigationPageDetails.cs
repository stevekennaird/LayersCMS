using System;

namespace LayersCMS.Data.Persistence.Models.Pages
{
    public class NavigationPageDetails
    {
        public virtual String DisplayName { get; set; }
        public virtual String Url { get; set; }
        public virtual Int32 SortOrder { get; set; }
    }
}
