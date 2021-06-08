using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamarinTask.ViewModels
{
    public class GalleryPageViewModel : BindableBase
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public GalleryPageViewModel(INavigationService navigationservice)
        {
            Title = "Gallery";
        }
    }
}
