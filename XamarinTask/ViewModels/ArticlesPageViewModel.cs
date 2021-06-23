using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using XamarinTask.Model;
using XamarinTask.Services;
namespace XamarinTask.ViewModels
{
    public class ArticlesPageViewModel : ViewModelBase
    {
        //private
        private HttpClient client;
        private List<Article> articles;
        private INavigationService navigationService;
        private IPageDialogService dialogService;
        //public
        public List<Article> Articles
        {
            get { return articles; }
            set { SetProperty(ref articles, value); }
        }
        public DelegateCommand ItemSelectedChanged { get; set; }
        public Article SelectdArticle { get; set; }
        //ctor
        public ArticlesPageViewModel(INavigationService navigationservice,IPageDialogService dialogservice)
            :base(navigationservice)
        { 
            client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(5);
            navigationService = navigationservice;
            dialogService = dialogservice;
            ItemSelectedChanged = new DelegateCommand(OnItemSelectedChanged);
        }
        /// <summary>
        /// when an item gets selected from the articles list
        /// pass selected article to navigation parameters
        /// navigat to article details page 
        /// </summary>
        private void OnItemSelectedChanged()
        {
            var parameters = new NavigationParameters {
                { Constants.selectedArticleKey,SelectdArticle}
            };
            navigationService.NavigateAsync(Constants.ArticlesDetailsPage,parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Title = parameters.GetValue<string>(Constants.TitleKey).ToUpper();
            GetArticlesList();
        }
        /// <summary>
        /// initiates the API calls and get its the articles list
        /// if request failed desplay ana alert message
        /// </summary>
        private async void GetArticlesList()
        {
            string content = await HttpService.Instance.SendHttpWebRequest(WebConstants.ArticlesUrl);
            if (string.IsNullOrEmpty(content))
            {
                await dialogService.DisplayAlertAsync("Alert", "Somthing went wrong, please try again later", "OK");
            }
            else
            {
                Root root = JsonConvert.DeserializeObject<Root>(content);
                Articles = root.articles;
            }
        }
    }
}
