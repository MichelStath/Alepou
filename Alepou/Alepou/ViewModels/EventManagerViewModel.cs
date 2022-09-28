using System.Windows.Input;
using Alepou.Models.Services;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;

namespace Alepou.ViewModels
{
    public class EventManagerViewModel
    {
        public EventManagerViewModel()
        {
            _messageService = DependencyService.Get<Services.IMessageService>();
            _navigationService = DependencyService.Get<Services.INavigationService>();

            GoToEventAdderCommand = new Command(OnGoToEventAdder);
            EditEventCommand = new Command(OnEditEvent);
            DeleteEventCommand = new Command(OnDeleteEvent);

            SelectedCalendarInlineEvent = SessionManager.CurrentEvent;
        }

        private readonly Services.IMessageService _messageService;
        private readonly Services.INavigationService _navigationService;

        public ICommand GoToEventAdderCommand { get; private set; }
        public ICommand EditEventCommand { get; private set; }
        public ICommand DeleteEventCommand { get; private set; }

        public CalendarInlineEvent SelectedCalendarInlineEvent { get; set; }

        public void OnGoToEventAdder()
        {
            _navigationService.PushAsync(new Views.EventAddPage());
        }

        public void OnEditEvent()
        {
            _navigationService.PushAsync(new Views.EventEditPage());
        }

        public void OnDeleteEvent()
        {
            CalendarEventManager.CalendarInlineEvents.Remove(SelectedCalendarInlineEvent);
            var calendarEventData = Database.GetEventFromDataAsync(SelectedCalendarInlineEvent.Subject, SelectedCalendarInlineEvent.StartTime);
            Database.DeleteEventAsync(calendarEventData.Id);
            _navigationService.PushAsync(new Views.CalendarPage());
        }
    }
}
