using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinTask.Model;

namespace XamarinTask.Services
{
    class ArticlesService:IArticlesService
    {
        public ArticlesService()
        {
            
        }
        public async Task<List<Article>> GetArticlesList(string url)
        {
            string content = await HttpService.Instance.Get(WebConstants.ArticlesUrl);
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
