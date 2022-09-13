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
    public partial class HomePage : ContentPage
    {
        public HomePage(string currentUser)
        {
            InitializeComponent(); 
            txtWelocomeUser.Text = "Welcome " + currentUser;
        }

        

        private async void Notification_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotificationPage(), true);     
        }

        private async void Calendar_Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void Today_Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void Add_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEventPage(), true);
        }
    }
}