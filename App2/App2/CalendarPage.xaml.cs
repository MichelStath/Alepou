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
            SfCalendar calendar = new SfCalendar();                     
            calendar.MinDate = new DateTime(2021, 1, 1);
            calendar.MaxDate = new DateTime(2030, 1, 1);
            this.Content = calendar;
        }

        [Obsolete]
        private async void calendar_OnCalendarTapped(object sender, CalendarTappedEventArgs e)
        {
            SfCalendar calendar = (sender as SfCalendar);
            DateTime date = e.datetime;
            await Navigation.PushAsync(new LoginUI(), true);
        }
    }
}