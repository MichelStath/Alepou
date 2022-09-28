using Alepou.Models.Services;
using Alepou.ViewModels;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Alepou.Models
{
    public class CalendarEvent : BaseViewModel
    {
        public CalendarEvent()
        {
            Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            Participants = new ObservableCollection<UserData>();
        }

        public CalendarEvent(
            DateTime date,
            int duration,
            string description,
            List<UserData> participants)
        {
            Date = date;
            Duration = duration;
            Description = description;
            Participants = new ObservableCollection<UserData>(participants);
        }

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

        private ObservableCollection<UserData> _participantsList;
        public ObservableCollection<UserData> Participants
        {
            get => _participantsList;
            private set => SetProperty(ref _participantsList, value);
        }

        public CalendarInlineEvent GetCalendarInlineEvent()
        {
            var subject = Description + "-Participants: ";
            foreach (var i in Participants)
            {
                subject += " " + i.Username;
            }

            return new CalendarInlineEvent
            {
                StartTime = Date,
                EndTime = Date.AddMinutes(Duration),
                Subject = subject,
                Color = GetRandomColor()
            };
        }

        public CalendarEventData GetCalendarEventData()
        {
            var subject = Description + "-Participants: ";
            foreach (var i in Participants)
            {
                subject += " " + i.Username;
            }

            return new CalendarEventData()
            {
                Date = Date,
                Duration = Duration,
                Description = subject,
                Participants = Participants.ToList()
            };
        }

        public Color GetRandomColor()
        {
            Random rand = new Random();
            int hue = rand.Next(255);
            return Color.FromHsv(
                hue / 255.0f,
                1.0f,
                1.0f
            );
        }
    }
}
