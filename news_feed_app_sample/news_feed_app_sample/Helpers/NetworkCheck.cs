using Xamarin.Essentials;

namespace news_feed_app_sample
{
    public static class NetworkCheck
    {
        public static bool IsInternet()
        {
            if (Connectivity.NetworkAccess==NetworkAccess.Internet)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}