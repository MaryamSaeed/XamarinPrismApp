using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
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
        //ctor
        public ArticleDetaiPageViewModel(INavigationService navigationService)
            :base(navigationService)
        {
          
        }
        /// <summary>
        /// displays the content of the article sent in the navigation parameter
        /// </summary>
        /// <param name="parameters">navegation parametrs with the article</param>
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var selectedarticle = parameters.GetValue<Article>(Constants.selectedArticleKey);
            ArticleTitle = selectedarticle.title;
            ArticleAuther = selectedarticle.author;
            ArticleText = selectedarticle.description;
            ImageSource = selectedarticle.urlToImage;
        }
    }
}
