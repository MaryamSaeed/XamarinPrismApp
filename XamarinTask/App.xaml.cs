using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using XamarinTask.ViewModels;
using XamarinTask.Views;
using XamarinTask.Services;

namespace XamarinTask
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("MainPage/NavigationPage/Articles?title=Articles");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<IHttpService, HttpService>();
            containerRegistry.Register<IArticlesService, ArticlesService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<Articles, ArticlesPageViewModel>();
            containerRegistry.RegisterForNavigation<EmptyPage, EmptyPageViewModel>();
            containerRegistry.RegisterForNavigation<ArticleDetailPage, ArticleDetaiPageViewModel>();
            
            //ToDo: regestration of HTTP service and its interface
            //ToDo: regestration of Articles service and its interface
        }
    }
}