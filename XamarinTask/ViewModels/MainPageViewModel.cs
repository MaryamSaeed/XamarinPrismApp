using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinTask.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand<string> NavigateToPage { get; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            NavigateToPage = new DelegateCommand<string>(OnNavigateToPage);
        }
        private async void OnNavigateToPage(string pagename)
        {
            await NavigationService.NavigateAsync($"NavigationPage/{pagename}");
        }
    }
}
