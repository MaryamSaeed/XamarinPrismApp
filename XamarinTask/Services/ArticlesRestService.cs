using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinTask.Model;

namespace XamarinTask.Services
{
    class ArticlesRestService : IRestService<Article>
    {
        public async Task<List<Article>> Get(string url)
        {
            string content = await HttpService.Instance.SendHttpRequest(WebConstants.ArticlesUrl);
            if (string.IsNullOrEmpty(content))
            {
                return null;
            }
            else
            {
                var root = JsonConvert.DeserializeObject<Root>(content);
                List<Article> articles = root.articles;
                return articles;
            }
        }
    }
}
