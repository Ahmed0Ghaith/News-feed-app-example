using System;

namespace news_feed_app_sample.Models
{
    internal class Article
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public string Date { get => PublishedAt.ToString("MMMM dd yyyy"); }
        public DateTime PublishedAt { get; set; }
    }
}
