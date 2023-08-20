using news_feed_app_sample.Services;
using news_feed_app_sample.ViewModels;
using news_feed_app_sample.Views;
using Prism;
using Prism.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace news_feed_app_sample
{
    public partial class App : Prism.Unity.PrismApplication
    {

        internal const string BaseUrl= "https://newsapi.org";

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer)
        {

        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage,MainPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPageFlyout, MainPageViewModel>();

            containerRegistry.RegisterForNavigation<ExplorePage,ExplorePageViewModel>();
            containerRegistry.RegisterForNavigation<NewsDetailsPage,NewsDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<LiveChatPage>();
            containerRegistry.RegisterForNavigation<GallryPage>();
            containerRegistry.RegisterForNavigation<MagazinePage>();
            containerRegistry.RegisterForNavigation<WishListPage>();

            containerRegistry.Register<INewsServices,NewsServices>();

        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("MainPage");


        }


        #region MenuList

        #endregion

    }
}
