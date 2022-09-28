using System.Windows.Input;
using Alepou.Models.Services;
using Xamarin.Forms;

namespace Alepou.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public RegisterViewModel()
        {
            _messageService = DependencyService.Get<Services.IMessageService>();
            _navigationService = DependencyService.Get<Services.INavigationService>();

            GoToLoginCommand = new Command(OnGoToLogin);
            RegisterCommand = new Command(OnRegister);
        }

        private readonly Services.IMessageService _messageService;
        private readonly Services.INavigationService _navigationService;

        public ICommand GoToLoginCommand { get; private set; }
        public ICommand RegisterCommand { get; private set; }

        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private async void OnGoToLogin()
        {
            await _navigationService.PushAsync(new Views.LoginPage());
        }

        private async void OnRegister()
        {
            if (Username == null || Password == null)
            {
                await _messageService.ShowAlertAsync("Please select a username and a password");
                return;
            }

            var user = new UserData
            {
                Username = Username,
                Password = Password
            };

            var id = await Database.AddUserAsync(user);
            user.ID = id;
            SessionManager.CurrentUser = user;
            await _navigationService.PushAsync(new Views.HomePage());
        }
    }
}
