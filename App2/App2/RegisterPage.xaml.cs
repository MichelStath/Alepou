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

        private bool CheckUsernameIfNotExist(string username)
        {
            if (username == "1")
            {
                return false;
            }

            return true;

        }

        private void RegisterUser(string username , string password)
        {
            // INSERT QUERY
        }

        private async void Register_Button_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new RegisterPage(), true);
            if (CheckUsernameIfNotExist(txtUsername.Text))
            {
                RegisterUser(txtUsername.Text, txtPassword.Text);
                await Navigation.PushAsync(new LoginUI(), true);
            }
            else
            {
                await DisplayAlert("Alert", "Pick another Username", "OK!");
            }
        }

        private async void GoToLoginPage_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginUI(), true);
        }
    }
}