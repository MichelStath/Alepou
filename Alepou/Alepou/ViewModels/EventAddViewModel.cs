using Alepou.Models;
using Alepou.Models.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Alepou.ViewModels
{
    public class EventAddViewModel : BaseViewModel
    {
        public EventAddViewModel()
        {
            _messageService = DependencyService.Get<Services.IMessageService>();

            CalendarEvent = new CalendarEvent();

            AddParticipantCommand = new Command(OnAddParticipant);
            RemoveParticipantCommand = new Command(OnRemoveParticipant);
            AddEventCommand = new Command(OnAddEvent);
        }

        private readonly Services.IMessageService _messageService;

        public ICommand AddParticipantCommand { get; private set; }
        public ICommand RemoveParticipantCommand { get; private set; }
        public ICommand AddEventCommand { get; private set; }

        public CalendarEvent CalendarEvent { get; private set; }

        private TimeSpan _time;
        public TimeSpan Time
        {
            get => _time;
            set 
            {
                CalendarEvent.Date = new DateTime(CalendarEvent.Date.Year, CalendarEvent.Date.Month, CalendarEvent.Date.Day, 0, 0, 0);
                CalendarEvent.Date = CalendarEvent.Date.Add(value);
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

        private async void OnAddParticipant()
        {
            try
            {
                var user = await Database.GetUserAsync(UserToAdd);
                CalendarEvent.Participants.Add(user);
                UserToAdd = "";
            }
            catch (Exception)
            {
                await _messageService.ShowAlertAsync("Username doesn't exist!");
            }
        }

        private void OnRemoveParticipant()
        {
            CalendarEvent.Participants.Remove((UserData)SelectedUser);
        }

        private async void OnAddEvent()
        {
            await Database.AddEventAsync(CalendarEvent.GetCalendarEventData());
            CalendarEventManager.CalendarInlineEvents.Add(CalendarEvent.GetCalendarInlineEvent());
            await _messageService.ShowNotificationAsync("Event added");
        }
    }
}
