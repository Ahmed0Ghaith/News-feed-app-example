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
    internal interface INewsServices
    {
      Task<Tuple<NewsResponse, bool, string>> GetNews(string Source);
   


    }
}
