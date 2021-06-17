using Prism.Commands;
using Prism.Navigation;

namespace XamarinTask.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        //private 
        private INavigationService navigationService;
        //command
        public DelegateCommand NavigateToArticles { get; set; }
        public DelegateCommand NavigateToGallery { get; set; }
        public DelegateCommand NavigateToWishList { get; set; }
        public DelegateCommand NavigateToLiveChat { get; set; }
        public DelegateCommand NavigateToExploreNews { get; set; }
        //ctor
        public MainPageViewModel(INavigationService navigationservice)
            : base(navigationservice)
        {
            Title = "main page";
            navigationService = navigationservice;
            InitCommand();
        }
        private void InitCommand()
        {
            NavigateToArticles = new DelegateCommand(OnNavigateToArticles);
            NavigateToGallery = new DelegateCommand(OnNavigateToGallery);
            NavigateToWishList = new DelegateCommand(OnNavigateToWishList);
            NavigateToLiveChat = new DelegateCommand(OnNavigateToLiveChat);
            NavigateToExploreNews = new DelegateCommand(OnNavigateToExploreNews);
        }
        private void OnNavigateToArticles()
        {
            var navparameters = new NavigationParameters {
                {Constants.TitleKey,Constants.ArticlesPageTitle }
            };
            navigationService.NavigateAsync("NavigationPage/" + Constants.ArticlesPage,navparameters);
        }
        private void OnNavigateToGallery()
        {
            NavigateToEmptyPage(Constants.GalleryPageTitle, false);
        }
        private void OnNavigateToWishList()
        {
            NavigateToEmptyPage(Constants.WishListPageTitle, false);
        }
        private void OnNavigateToLiveChat()
        {
            NavigateToEmptyPage(Constants.LiveChatPageTitle, true);
        }
        private void OnNavigateToExploreNews()
        {
            NavigateToEmptyPage(Constants.OnlineNewsPageTitle, true);
        }
        /// <summary>
        /// navigating to an ampty page witha title and status
        /// </summary>
        /// <param name="titlevalue">page title</param>
        /// <param name="pagestatus">status of message screen</param>
        private void NavigateToEmptyPage(string titlevalue, bool pagestatus)
        {
            var navparameters = new NavigationParameters {
                {Constants.TitleKey,titlevalue },
                {Constants.StatusKey,pagestatus }
            };
            navigationService.NavigateAsync("NavigationPage/"+Constants.EmptyPage, navparameters);
        }
    }
}
