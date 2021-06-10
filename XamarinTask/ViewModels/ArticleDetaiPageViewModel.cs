using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XamarinTask.WebService;

namespace XamarinTask.ViewModels
{
    public class ArticleDetaiPageViewModel : BindableBase,INavigationAware 
    {
        //private
        private string title;
        private string articleText;
        private string articleTitle;
        private string imageSource;
        private string articleAuther;
        //public
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
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
        public ArticleDetaiPageViewModel()
        {
            Title = "Article Details".ToUpper();

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }
        /// <summary>
        /// displays the content of the article sent in the navigation parameter
        /// </summary>
        /// <param name="parameters">naveration parametrs with the article</param>
        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var selectedarticle = parameters.GetValue<Article>(Constants.selectedArticle);
            ArticleTitle = selectedarticle.title;
            ArticleAuther = selectedarticle.author;
            ArticleText = selectedarticle.description;
            ImageSource = selectedarticle.urlToImage;
        }
    }
}
