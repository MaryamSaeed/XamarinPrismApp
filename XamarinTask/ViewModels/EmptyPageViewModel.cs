using Prism.Mvvm;
using Prism.Navigation;

namespace XamarinTask.ViewModels
{
    public class EmptyPageViewModel : ViewModelBase
    {
        //private
        private string screenmessage;
        //public
        public string ScreenMessage
        {
            get { return screenmessage; }
            set { SetProperty(ref screenmessage, value); }
        }
        //ctor
        public EmptyPageViewModel(INavigationService navigationservice)
            :base(navigationservice)
        {
            Title = "Empty Page Title";
        }
        /// <summary>
        /// desplays a title and a screen message based on the navigation parameter
        /// </summary>
        /// <param name="parameters">navigation parameter</param>
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Title = parameters.GetValue<string>("title").ToUpper();
            var status = parameters.GetValue<bool>("status");
            if (status)
                ScreenMessage = Constants.NoService;
            else
                ScreenMessage = Constants.NoItems;
        }
    }
}
