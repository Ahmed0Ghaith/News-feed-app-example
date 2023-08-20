using news_feed_app_sample.Resources;
using Newtonsoft.Json;
using Polly;
using Prism.Ioc;
using Prism.Navigation;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace news_feed_app_sample.Helpers
{
    internal class HttpManager
    {


   
        public static async Task<Tuple<T, bool, string>> GetAsync<T>(string BaseUrl,string requestUrl) where T : class

        {
            try
            {
                if (NetworkCheck.IsInternet())
                {
                    var options = new RestClientOptions(BaseUrl)
                    {
                        MaxTimeout = -1,
                    };
                    var client = new RestClient(options);
                    var request = new RestRequest(requestUrl, Method.Get);
                    RestResponse response =  client.ExecuteAsync(request).GetAwaiter().GetResult();




                    if (response != null)
                        {
                            if (response.IsSuccessStatusCode)
                        {
                            try
                            {
                                var responseJson =  response.Content;
                                var JsonObject = JsonConvert.DeserializeObject<T>(responseJson);
                                return Tuple.Create(JsonObject, true, "");

                            }
                            catch (Exception ex)
                            { throw ex; }




                        }
                        else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                          
                            return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LanguageResource.SessionExpired);
                        }
                        else
                        {

                            return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LanguageResource.ServerError);
                        }
                    }
                    else
                    {
                        return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LanguageResource.ServerErrorOrNoInternetConnection);
                    }

                }
                else
                {
                    return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, LanguageResource.NoInternet);
                }

            }
            catch (System.Exception exp)
            {
                return Tuple.Create((T)Activator.CreateInstance(typeof(T)), false, exp.Message);
            }

        }
    }
}
