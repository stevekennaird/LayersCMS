using System;

namespace LayersCMS.Data.Persistence.Models.Pages
{
    public class NavigationPageDetails
    {
        public virtual Int32 Id { get; set; }
        public virtual String DisplayName { get; set; }
        public virtual String Url { get; set; }
        public virtual Int32 SortOrder { get; set; }
        public virtual Int32? ParentId { get; set; }
    }
}
