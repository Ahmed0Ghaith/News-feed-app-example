using news_feed_app_sample.Models;
using news_feed_app_sample.Services;
using news_feed_app_sample.Views;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace news_feed_app_sample.ViewModels
{
    internal class MainPageViewModel : BaseViewMode
    {

        #region  Propertise
        public ObservableCollection<Article> NewsList { get { return _newsList; } set { _newsList = value; RaisePropertyChanged(); } }
        public bool FristTimeLoad { get; set; } = true;

        #endregion

        #region  Fields
        ObservableCollection<Article> _newsList;
        private readonly INewsServices _newsServices;

        #endregion


        #region Initilize
        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService, INewsServices newsServices) : base(navigationService, dialogService)
        {
            this._newsServices = newsServices;

        }
        public override void Initialize(INavigationParameters parameters)
        {
            NewsList = new ObservableCollection<Article>();

            base.Initialize(parameters);
        }
        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (!FristTimeLoad)
                return;

           await  LoadNews("/v1/articles?source=the-next-web&apiKey=533af958594143758318137469b41ba9");
          await   LoadNews("/v1/articles?source=associated-press&apiKey=533af958594143758318137469b41ba9");
            FristTimeLoad = false ;
        }
        #endregion
        #region Commands&Methods
        private async Task LoadNews(string Source)
        {
            try
            {
                IsBusy = true;
                var res = await _newsServices.GetNews(Source);
                if (res.Item2)
                {
                    foreach (var item in res.Item1.Articles)
                    {
                        NewsList.Add(item);
                    }
                }
                else
                {
                    await DialogService.DisplayAlertAsync($"Error", res.Item3, "Cancel");
                }
            }
            catch (Exception ex)
            {
                await DialogService.DisplayAlertAsync("Error", ex.Message, "Cancel");

            }
            finally
            {
                IsBusy = false;

            }
        }


        public DelegateCommand<MainPageFlyoutMenuItem> GoToPageCommand
        {
            get
            {
                return new DelegateCommand<MainPageFlyoutMenuItem>(async (item) =>
                {
                    if (item != null)
                    {

                        var Newlist = MenuItemsList;
                        for (int i = 0; i < Newlist.Count; i++)
                        {
                            Newlist[i].IsSelected = Newlist[i].Id == item.Id;     
                        }
                        
                       
                        MenuItems = new ObservableCollection<MainPageFlyoutMenuItem>(Newlist);
                        await NavigationService.NavigateAsync("NavigationPage/" + item.TargetType.Name);

                    }

                });

            }
        }
       
        #endregion
    }
}
