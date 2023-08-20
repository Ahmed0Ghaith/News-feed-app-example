using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using news_feed_app_sample.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace news_feed_app_sample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageFlyout : ContentPage
    {

        public MainPageFlyout()
        {
            InitializeComponent();

         
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}