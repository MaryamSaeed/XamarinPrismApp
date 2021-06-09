using Prism.Mvvm;
using Prism.Navigation;

namespace XamarinTask.ViewModels
{
    public class EmptyPageViewModel : BindableBase, INavigationAware
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
        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Title = parameters.GetValue<string>("title").ToUpper();
            var status = parameters.GetValue<bool>("status");
            if (status)
                ScreenMessage = Constants.NoService;
            else
                ScreenMessage = Constants.NoItems;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }
    }
}
