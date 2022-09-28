using Syncfusion.SfCalendar.XForms;
using System;
using System.Drawing;

namespace Alepou.Models.Services
{
    public static class CalendarEventManager
    {
        public static CalendarEventCollection CalendarInlineEvents;
        static CalendarEventManager()
        {
            CalendarInlineEvents = new CalendarEventCollection();
            LoadEvents();
        }

        static async void LoadEvents()
        {
            var events = await Database.GetEventsAsync();  
            foreach (var e in events)
            {
                CalendarInlineEvents.Add(new CalendarInlineEvent
                {
                    StartTime = e.Date,
                    EndTime = e.Date.AddMinutes(e.Duration),
                    Subject = e.Description,
                    Color = Color.Violet
                });
            }
        }
    }
}
