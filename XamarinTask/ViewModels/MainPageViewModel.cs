using Prism.Commands;
using Prism.Navigation;

namespace XamarinTask.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        //command
        public DelegateCommand<string> NavigateToPage { get; }
        //ctor
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            NavigateToPage = new DelegateCommand<string>(OnNavigateToPage);
        }
        private async void OnNavigateToPage(string pagepath)
        {
            await NavigationService.NavigateAsync($"NavigationPage/{pagepath}");
        }
    }
}
