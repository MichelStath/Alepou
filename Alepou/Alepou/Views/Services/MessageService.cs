using Alepou.ViewModels.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Alepou.Views.Services
{
    public class MessageService : IMessageService
    {
        public async Task ShowAsync(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task ShowAlertAsync(string message)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Alert",
                message,
                "Try Again"
            );
        }

        public async Task ShowNotificationAsync(string message)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Notification",
                message,
                "Ok"
            );
        }
    }
}
