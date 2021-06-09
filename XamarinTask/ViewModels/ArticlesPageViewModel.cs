using Prism.Mvvm;

namespace XamarinTask.ViewModels
{
    public class ArticlesPageViewModel : BindableBase
    {
        //private
        private string title;
        //public
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public ArticlesPageViewModel()
        {
            Title = "Articles".ToUpper();
        }
    }
}
