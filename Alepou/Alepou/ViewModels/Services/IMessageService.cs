using System.Threading.Tasks;

namespace Alepou.ViewModels.Services
{
    public interface IMessageService
    {
        Task ShowAsync(string title, string message, string cancel = "Ok");
        Task ShowAlertAsync(string message);
        Task ShowNotificationAsync(string message);
    }
}
