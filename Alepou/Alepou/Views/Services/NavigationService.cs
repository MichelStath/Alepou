using Alepou.ViewModels.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Alepou.Views.Services
{
    public class NavigationService : INavigationService
    {
        public async Task PushAsync(Page page, bool animated)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page, animated);
        }
    }
}
