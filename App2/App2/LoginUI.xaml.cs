using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUI : ContentPage
    {
        
        public LoginUI()
        {
            InitializeComponent();            
        }

        private bool CheckCredentials(string username ,string password)
        {
            if (username == "1" || password== "1")
            {
                return true;
            }

            return false;
            
        }



        private async void Login_Button_Clicked(object sender, EventArgs e)
        {
            if (CheckCredentials(txtUsername.Text, txtPassword.Text))
            {
                await Navigation.PushAsync(new HomePage(), true);
            }
            else
            {
                await DisplayAlert("Alert", "Wrong Username OR Password", "Try again!");
            }     
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage(), true);
        }
    }
}