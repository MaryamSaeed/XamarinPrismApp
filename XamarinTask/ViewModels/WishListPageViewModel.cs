using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamarinTask.ViewModels
{
    public class WishListPageViewModel : BindableBase
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public WishListPageViewModel()
        {
            Title = "Wish List";
        }
    }
}
