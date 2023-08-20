using news_feed_app_sample.Models;
using news_feed_app_sample.Views;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace news_feed_app_sample.ViewModels
{
    internal class BaseViewMode : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        #region Fields
        public List<MainPageFlyoutMenuItem> MenuItemsList = new List<MainPageFlyoutMenuItem>(


                  new[]
             {
                    new MainPageFlyoutMenuItem { Id = 0,Icon="explore.png", Title = "Explore",TargetType=typeof(ExplorePage) },
                    new MainPageFlyoutMenuItem { Id = 1,Icon="live.png", Title = "Live Chat" ,TargetType=typeof(LiveChatPage)
},
                    new MainPageFlyoutMenuItem { Id = 2, Icon = "gallery.png", Title = "Gallery", TargetType = typeof(GallryPage) },
                    new MainPageFlyoutMenuItem { Id = 3, Icon = "wishlist.png", Title = "Wish List", TargetType = typeof(WishListPage) },
                    new MainPageFlyoutMenuItem { Id = 4, Icon = "emagazine.png", Title = "E-Magazine", TargetType = typeof(MagazinePage) },
          });
        protected INavigationService NavigationService { get; private set; }
        protected IPageDialogService DialogService { get; private set; }
        static bool FristLoading = true;
        #endregion
        #region Propertise
        bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                SetProperty(ref isBusy, value);
            }
        }

        public ObservableCollection<MainPageFlyoutMenuItem> MenuItems { 
            get { return _menuItems; }
            set
            {
                SetProperty(ref _menuItems, value);
            }
        }

        #endregion

        #region  Fields
        public ObservableCollection<MainPageFlyoutMenuItem> _menuItems;


        #endregion
        #region Initialize

        public BaseViewMode(INavigationService navigationService, IPageDialogService dialogService)
        {
            this.DialogService = dialogService;
            this.NavigationService = navigationService;
            Console.WriteLine(">>>>>>ViewModel......................................" + this.GetType().Name);
        }
        #endregion

        #region PagesLifeCycle


        public virtual void Destroy()
        {
        }

        public virtual async void Initialize(INavigationParameters parameters)
        {
            try
            {
                IsBusy = true;

                if (!FristLoading)
                    return;
                var Newlist = MenuItemsList;
                Newlist[0].IsSelected= true;
                MenuItems = new ObservableCollection<MainPageFlyoutMenuItem>(Newlist);
                FristLoading = false;
            }
            catch (Exception ex) { }
            finally { 
            IsBusy = false;
            }
            //  throw new NotImplementedException();
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
           
        }
       
        #endregion

    }
}
