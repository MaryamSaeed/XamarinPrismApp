﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamarinTask.ViewModels
{
    public class GalleryNavigationPageViewModel : BindableBase
    {
        //todo: empty page that derives its title and message from navigation parameters
        //private
        private string title;
        private string message;
        //public
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public string ScreenMessage
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }
        public GalleryNavigationPageViewModel()
        {
            Title = "Gallery";
            ScreenMessage = Constants.NoItems;
        }
    }
}
