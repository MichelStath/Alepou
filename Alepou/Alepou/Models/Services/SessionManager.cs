using Syncfusion.SfCalendar.XForms;

namespace Alepou.Models.Services
{
    public static class SessionManager
    {
        public static UserData CurrentUser = null;
        public static CalendarEventData OriginalEvent = null;
        public static CalendarInlineEvent CurrentEvent = null;
    }
}
