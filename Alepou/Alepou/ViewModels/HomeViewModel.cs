using Alepou.Models.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace Alepou.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            _navigationService = DependencyService.Get<Services.INavigationService>();

            GoToNotificationCommand = new Command(OnGoToNotification);
            GoToCalendarCommand = new Command(OnGoToCalendar);
            GoToEventManagerCommand = new Command(OnGoToEventManager);
            LogoutCommand = new Command(OnLogout);
        }

        private readonly Services.INavigationService _navigationService;

        public ICommand GoToNotificationCommand { get; private set; }
        public ICommand GoToCalendarCommand { get; private set; }
        public ICommand GoToEventManagerCommand { get; private set; }
        public ICommand LogoutCommand { get; private set; }

        public string WelcomeMessage
        { 
            get => "Welcome " + SessionManager.CurrentUser.Username;
        }

        private async void OnGoToNotification()
        {
            await _navigationService.PushAsync(new Views.NotificationPage());
        }

        private async void OnGoToCalendar()
        {
            await _navigationService.PushAsync(new Views.CalendarPage());
        }

        private async void OnGoToEventManager()
        {
            await _navigationService.PushAsync(new Views.EventAddPage());
        }

        private async void OnLogout()
        {
            SessionManager.CurrentUser = null;
            await _navigationService.PushAsync(new Views.LoginPage());
        }
    }
}
