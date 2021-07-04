using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace XamarinTask.Services
{
    class HttpService:IHttpService
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
        public async Task<string> Get(string url)
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
    }
}
