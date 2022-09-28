using Alepou.Models.Services;
using Xamarin.Forms;


namespace Alepou.Views
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // Inject Message Service.
            DependencyService.Register<ViewModels.Services.IMessageService, Services.MessageService>();
            // Inject Navigation Service.
            DependencyService.Register<ViewModels.Services.INavigationService, Services.NavigationService>();
            // Initialize Database.
            Database.Init();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart() {}

        protected override void OnSleep() {}

        protected override void OnResume() {}
    }
}
