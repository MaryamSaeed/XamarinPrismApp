using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinTask.Model;

namespace XamarinTask.ViewModels
{
    public class ArticleDetaiPageViewModel : ViewModelBase 
    {
        //private
        private string articleText;
        private string articleTitle;
        private string imageSource;
        private string articleAuther;
        private string url;
        private IPageDialogService dialogService;
        //public
        public string ArticleText
        {
            get { return articleText; }
            set { SetProperty(ref articleText, value); }
        }
        public string ImageSource
        {
            get { return imageSource; }
            set { SetProperty(ref imageSource, value); }
        }
        public string ArticleTitle
        {
            get { return articleTitle; }
            set { SetProperty(ref articleTitle, value); }
        }
        public string ArticleAuther
        {
            get { return articleAuther; }
            set { SetProperty(ref articleAuther, value); }
        }
        private DateTime publishedAt;
        public DateTime PublishedAt
        {
            get { return publishedAt; }
            set { SetProperty(ref publishedAt, value); }
        }
        public DelegateCommand OpenWebsite { get; set; }
        //ctor
        public ArticleDetaiPageViewModel(INavigationService navigationService, IPageDialogService dialogservice)
            :base(navigationService)
        {
            OpenWebsite = new DelegateCommand(OnOpenWebsite);
            dialogService = dialogservice;
        }
        /// <summary>
        /// displays the content of the article sent in the navigation parameter
        /// </summary>
        /// <param name="parameters">navegation parametrs with the article</param>
        public override void OnNavigatedTo(INavigationParameters parameters )
        {
            var selectedarticle = parameters.GetValue<Article>(Constants.selectedArticleKey);
            ArticleTitle = selectedarticle.title;
            ArticleAuther = selectedarticle.author;
            ArticleText = selectedarticle.description;
            ImageSource = selectedarticle.urlToImage;
            PublishedAt = selectedarticle.publishedAt;
            url = selectedarticle.url;
        }
        private async void OnOpenWebsite()
        {
            try
            {
                await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
            }
            catch 
            {
                await dialogService.DisplayAlertAsync("Alert", "Somthing went wrong, please try again later", "OK");
            }
        }
    }
}
