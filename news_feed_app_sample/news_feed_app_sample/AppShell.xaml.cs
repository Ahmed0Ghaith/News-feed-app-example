using news_feed_app_sample.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace news_feed_app_sample
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewsDetailsPage), typeof(NewsDetailsPage));
        //    Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}
