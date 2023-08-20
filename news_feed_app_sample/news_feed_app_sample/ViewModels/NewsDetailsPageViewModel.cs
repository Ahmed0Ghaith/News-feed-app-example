using news_feed_app_sample.Models;
using news_feed_app_sample.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Text;

namespace news_feed_app_sample.ViewModels
{
    internal class NewsDetailsPageViewModel : BaseViewMode
    {
        #region  Propertise
        public Article NewsDetails { get { return _newsDetails; } set { _newsDetails = value; RaisePropertyChanged(); } }

        #endregion

        #region  Fields
        Article _newsDetails = new Article();

        #endregion


        #region Initialize
        public NewsDetailsPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
        }
        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
           
        }
      
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
            Article Article = parameters["SelectdArticle"] as Article;
            if (parameters["SelectdArticle"] == null)
            {
                NavigationService.GoBackAsync();
                return;
            }
            NewsDetails = Article;

        }
        #endregion

        #region Commands&Methods
        public DelegateCommand OpenURLCommand
        {
            get
            {
                return new DelegateCommand( async ()=>
                {
                 await   Xamarin.Essentials.Launcher.OpenAsync(NewsDetails.Url);
                   
                });

            }
        }

        #endregion
    }
}
