using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XamarinTask.ViewModels
{
    public class ArticleDetaiPageViewModel : BindableBase
    {
        //private
        private string title;
        //public
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public string ArticleText { get; set; }
        public Image ArticleImage { get; set; }
        //ctor
        public ArticleDetaiPageViewModel()
        {
            Title = "Article Details".ToUpper();

        }
    }
}
