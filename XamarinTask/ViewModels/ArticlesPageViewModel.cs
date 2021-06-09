using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XamarinTask.WebService;

namespace XamarinTask.ViewModels
{
    public class ArticlesPageViewModel : BindableBase,INavigationAware
    {
        //private
        private string title;
        private HttpClient client;
        private List<Article> articles;
        private INavigationService navigationService;
        //public
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public List<Article> Articles
        {
            get { return articles; }
            set { SetProperty(ref articles, value); }
        }
        public DelegateCommand ItemSelectedChanged { get; set; }
        public Article SelectdArticle { get; set; }
        //ctor
        public ArticlesPageViewModel(INavigationService navigationservice)
        {
            Title = "Articles".ToUpper();
            client = new HttpClient();
            navigationService = navigationservice;
            ItemSelectedChanged = new DelegateCommand(OnItemSelectedChanged);
        }
        private void OnItemSelectedChanged()
        {
            var parameters = new NavigationParameters {
                { Constants.selectedArticle,SelectdArticle}
            };
            navigationService.NavigateAsync("ArticleDetailPage",parameters);
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
             GetArticlesWebRequest();
        }

        private async void GetArticlesWebRequest()
        {
            HttpResponseMessage requestcontent = await client.GetAsync(WebConstants.ArticlesUrl);
            if (requestcontent.IsSuccessStatusCode)
            {
                string content = await requestcontent.Content.ReadAsStringAsync();
                Root root = JsonConvert.DeserializeObject<Root>(content);
                Articles = root.articles;
            }
        }
    }
}
