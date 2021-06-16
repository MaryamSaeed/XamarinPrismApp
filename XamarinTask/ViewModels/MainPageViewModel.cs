using Prism.Commands;
using Prism.Navigation;

namespace XamarinTask.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        //command
        public DelegateCommand<string> NavigateToPage { get; }
        public DelegateCommand NavigateToArticles { get;}
        public DelegateCommand NavigateToGallery { get;}
        public DelegateCommand NavigateToWishList { get;}
        public DelegateCommand NavigateToLiveChat { get;}
        public DelegateCommand NavigateToExploreNews { get;}
        //ctor
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            InitCommand();
        }
        private void InitCommand()
        { 
            
        }
    }
}
