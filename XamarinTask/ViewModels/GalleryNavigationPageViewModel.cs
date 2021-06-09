using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamarinTask.ViewModels
{
    public class GalleryNavigationPageViewModel : BindableBase
    {
        private string titlr;
        public string Title
        {
            get { return titlr; }
            set { SetProperty(ref titlr, value); }
        }
        public GalleryNavigationPageViewModel()
        {
            Title = "Gallery";
        }
    }
}
