using Alepou.Models.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Alepou.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            InitializeComponent();
        }

        private async void CalendarInlineItemTapped(object sender, Syncfusion.SfCalendar.XForms.InlineItemTappedEventArgs e)
        {
            SessionManager.OriginalEvent = await Database.GetEventFromDataAsync(e.InlineEvent.Subject, e.InlineEvent.StartTime);
            SessionManager.CurrentEvent = e.InlineEvent;
            await Navigation.PushAsync(new EventManagerPage(), true);
        }
    }
}