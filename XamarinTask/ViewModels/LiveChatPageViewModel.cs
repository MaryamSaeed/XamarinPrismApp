using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamarinTask.ViewModels
{
    public class LiveChatPageViewModel : BindableBase
    {
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
        public LiveChatPageViewModel()
        {
            Title = "Live Chat";
            ScreenMessage = Constants.NoService;
        }
    }
}
