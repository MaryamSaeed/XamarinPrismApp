using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
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
        private IPageDialogService dialogService;
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
        public ArticlesPageViewModel(INavigationService navigationservice,IPageDialogService dialogservice)
        {
            Title = "Articles".ToUpper();
            client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(5);
            navigationService = navigationservice;
            dialogService = dialogservice;
            ItemSelectedChanged = new DelegateCommand(OnItemSelectedChanged);
        }
        /// <summary>
        /// when an item gets selected from the articles list
        /// navigat to article detail page
        /// </summary>
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
        /// <summary>
        /// initiates the API calls and get its the articles list
        /// </summary>
        private async void GetArticlesWebRequest()
        {
            HttpResponseMessage requestcontent = await client.GetAsync(WebConstants.ArticlesUrl);
            if (requestcontent.IsSuccessStatusCode)
            {
                string content = await requestcontent.Content.ReadAsStringAsync();
                Root root = JsonConvert.DeserializeObject<Root>(content);
                Articles = root.articles;
            }
            else
            {
                await dialogService.DisplayAlertAsync("Alert", "Somthing went wrong, please try again later", "OK");
            }
        }
    }
}
