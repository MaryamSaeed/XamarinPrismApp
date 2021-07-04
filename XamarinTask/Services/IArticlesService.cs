using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinTask.Model;

namespace XamarinTask.Services
{
    public interface IArticlesService
    {
        Task<List<Article>> GetArticlesList(string url);
    }
}
