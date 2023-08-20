using news_feed_app_sample.Helpers;
using news_feed_app_sample.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace news_feed_app_sample.Services
{
    internal class NewsServices : INewsServices
    {
        public async Task<Tuple<NewsResponse, bool, string>> GetNews(string Source)
        {
            var response = await HttpManager.GetAsync<NewsResponse>(App.BaseUrl,Source).ConfigureAwait(false);

            return response;
        }
    }
}
