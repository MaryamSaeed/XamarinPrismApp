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
        private string imageSource;
        public string ImageSource
        {
            get { return imageSource; }
            set { SetProperty(ref imageSource, value); }
        }
        //ctor
        public ArticleDetaiPageViewModel()
        {
            Title = "Article Details".ToUpper();

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var selectedarticle = parameters.GetValue<Article>(Constants.selectedArticle);
            ArticleText = selectedarticle.description;
            ImageSource = selectedarticle.urlToImage;
        }
    }
}
