using news_feed_app_sample.Models;
using news_feed_app_sample.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace news_feed_app_sample.ViewModels
{
    internal class ExplorePageViewModel : MainPageViewModel
    {
        #region  Propertise

        #endregion

        #region  Fields

        #endregion

        #region  Initalization
        public ExplorePageViewModel(INavigationService navigationService, IPageDialogService dialogService, INewsServices newsServices) : base(navigationService, dialogService, newsServices)
        {
        }
        public override async void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
           
        }
        #endregion
        #region  Commands&Mehods
    
        public DelegateCommand<Article> GoToArticleDetailsCommand
        {
            get
            {
                return new DelegateCommand<Article>(async (item) =>
                {
                    if (item != null)
                    {
                        var parameters = new NavigationParameters();
                        parameters.Add("SelectdArticle", item);

                        await NavigationService.NavigateAsync("NavigationPage/NewsDetailsPage", parameters);
                    }

                });

            }
        }



        #endregion

    }
}
