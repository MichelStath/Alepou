using Alepou.Models.Services;
using Syncfusion.SfCalendar.XForms;

namespace Alepou.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {
        public CalendarViewModel()
        {
            CalendarInlineEvents = CalendarEventManager.CalendarInlineEvents;
        }

        public CalendarEventCollection CalendarInlineEvents { get; set; }
    }
}
