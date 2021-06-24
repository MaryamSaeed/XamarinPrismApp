using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace XamarinTask.Services
{
    class HttpService
    {
        //private 
        private HttpClient httpClient;
        private static HttpService instance;
        //public
        public static HttpService Instance
        {
            get
            {
                if (instance == null)
                    instance = new HttpService();
                return instance;
            }
        }
        //ctor
        private HttpService()
        {
            httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(5);
        }
        public async Task<string> SendHttpRequest(string url)
        {
            string jsontext = null;
            try
            {
                HttpResponseMessage requestresponse = await httpClient.GetAsync(url);
                if (requestresponse.IsSuccessStatusCode)
                {
                    jsontext = await requestresponse.Content.ReadAsStringAsync();
                    return jsontext;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return jsontext;
        }
        //ToDo: implement IHttpService
    }
}
