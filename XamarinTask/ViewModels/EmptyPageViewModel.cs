using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamarinTask.ViewModels
{
    public class EmptyPageViewModel : BindableBase,INavigationAware
    {
        //private
        private string title;
        private string screenmessage;
        private INavigationService navigationService;
        //public
        public string ScreenMessage
        {
            get { return screenmessage; }
            set { SetProperty(ref screenmessage, value); }
        }
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public EmptyPageViewModel(INavigationService navigationservice)
        {
            Title = "Empty Page Title";
            navigationService = navigationservice;
        }
        public  void OnNavigatedTo(INavigationParameters parameters)
        {
            Title = parameters.GetValue<string>("title").ToUpper();
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }
    }
}
