using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            InitializeComponent();
            
        }

        private void showEvents(DateTime selectedDate)
        {

        }

        [Obsolete]
        private async void calendar_OnCalendarTapped(object sender, CalendarTappedEventArgs e)
        {           
            DateTime selectedDate = e.datetime;
            //await Navigation.PushAsync(new LoginUI(), true);
            await DisplayAlert("Alert", selectedDate.ToString(), "OK");
            showEvents(selectedDate);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            DateTime testdate = new DateTime();
            testdate = calendar.SelectedDate.Value;
            //await DisplayAlert("Alert", testdate.ToString(), "OK");
        }
    }
}