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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void Register_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage(), true);
        }

        private async void GoToLoginPage_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginUI(), true);
        }
    }
}