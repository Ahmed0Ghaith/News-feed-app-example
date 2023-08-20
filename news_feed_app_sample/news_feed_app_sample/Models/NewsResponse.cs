using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace news_feed_app_sample.Models
{

    internal class NewsResponse
    {
        public string Status { get; set; }
        public string Source { get; set; }
        public string SortBy { get; set; }
        public ObservableCollection<Article> Articles { get; set; }
    }
}
