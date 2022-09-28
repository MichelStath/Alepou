using Alepou.Models.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Syncfusion.SfCalendar.XForms;

namespace Alepou.ViewModels
{
    public class EventEditViewModel : BaseViewModel
    {
        public EventEditViewModel()
        {
            _messageService = DependencyService.Get<Services.IMessageService>();

            var cEvent = SessionManager.CurrentEvent;
            Time = cEvent.StartTime.Subtract(new DateTime(cEvent.StartTime.Year, cEvent.StartTime.Month, cEvent.StartTime.Day, 0, 0, 0));
            Date = new DateTime(cEvent.StartTime.Year, cEvent.StartTime.Month, cEvent.StartTime.Day, 0, 0, 0);
            Duration = (int)cEvent.EndTime.Subtract(cEvent.StartTime).TotalMinutes;
            Description = cEvent.Subject.Split('-')[0];
            ParticipantString = "-" + cEvent.Subject.Split('-')[1];

            EditEventCommand = new Command(OnEditEvent);
        }

        private readonly Services.IMessageService _messageService;

        public ICommand EditEventCommand { get; private set; }

        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        private int _duration;
        public int Duration
        {
            get => _duration;
            set => SetProperty(ref _duration, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public CalendarEventData OriginalEvent { get; set; }
        public string ParticipantString { get; set; }

        private TimeSpan _time;
        public TimeSpan Time
        {
            get => _time;
            set
            {
                Date = new DateTime(Date.Year, Date.Month, Date.Day, 0, 0, 0);
                Date = Date.Add(value);
                SetProperty(ref _time, value);
            }
        }

        private string _userToAdd;
        public string UserToAdd
        {
            get => _userToAdd;
            set => SetProperty(ref _userToAdd, value);
        }

        private UserData _selectedUser;
        public object SelectedUser
        {
            get => _selectedUser;
            set => SetProperty(ref _selectedUser, (UserData)value);
        }

        private async void OnEditEvent()
        {
            Description += ParticipantString;
            await Database.AddEventAsync(new CalendarEventData
            {
                ID = SessionManager.OriginalEvent.ID,
                Date = Date,
                Description = Description,
                Duration = Duration,
                Participants = SessionManager.OriginalEvent.Participants

            });

            CalendarEventManager.CalendarInlineEvents.Remove(SessionManager.CurrentEvent);
            CalendarEventManager.CalendarInlineEvents.Add(new CalendarInlineEvent
            {
                StartTime = Date,
                EndTime = Date.AddMinutes(Duration),
                Subject = Description
            });
            await _messageService.ShowNotificationAsync("Event Edited");
        }
    }
}
