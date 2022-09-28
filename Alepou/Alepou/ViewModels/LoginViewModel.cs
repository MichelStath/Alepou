using Xamarin.Forms;
using System.Windows.Input;
using Alepou.Models.Services;
using System;

namespace Alepou.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            _messageService = DependencyService.Get<Services.IMessageService>();
            _navigationService = DependencyService.Get<Services.INavigationService>();

            LoginCommand = new Command(OnLogin);
            GoToRegisterCommand = new Command(OnGoToRegister);
        }

        private readonly Services.IMessageService _messageService;
        private readonly Services.INavigationService _navigationService;

        public ICommand LoginCommand { get; private set; }
        public ICommand GoToRegisterCommand { get; private set; }

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

        private async void OnLogin()
        {
            try
            {
                var user = await Database.GetUserFromCredentianls(Username, Password);
                SessionManager.CurrentUser = user;
                await _navigationService.PushAsync(new Views.HomePage(), true);
            }
            catch (Exception)
            {
                await _messageService.ShowAlertAsync("Invalid username or password");
            }
        }

        private async void OnGoToRegister()
        {
            await _navigationService.PushAsync(new Views.RegisterPage(), true);
        }
    }
}
