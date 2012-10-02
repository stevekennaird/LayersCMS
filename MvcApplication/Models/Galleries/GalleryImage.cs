namespace QuickWin.MvcApplication.Models.Galleries
{
    public class GalleryImage
    {
        public GalleryImage(string imageUrl, string title, string caption)
        {
            ImageUrl = imageUrl;
            Title = title;
            Caption = caption;
        }

        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }

    }
}