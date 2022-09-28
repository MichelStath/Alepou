using Alepou.Models.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Alepou.ViewModels
{
    internal class NotificationViewModel : BaseViewModel
    {
        public NotificationViewModel()
        {
            Notifications = new ObservableCollection<Notification>();
            _ = LoadNotifications();
        }

        public ObservableCollection<Notification> Notifications { get; set; }

        public async Task LoadNotifications()
        {
            var currUserID = SessionManager.CurrentUser.ID;
            var userNotifications = await Database.GetNotificationsFromUserAsync(currUserID);
            foreach (var i in userNotifications)
            {
                Notifications.Add(i);
            }
        }
    }
}
