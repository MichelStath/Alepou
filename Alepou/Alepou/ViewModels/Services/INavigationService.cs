using System.Threading.Tasks;
using Xamarin.Forms;

namespace Alepou.ViewModels.Services
{
    public interface INavigationService
    {
        Task PushAsync(Page page, bool animated = true);
    }
}
