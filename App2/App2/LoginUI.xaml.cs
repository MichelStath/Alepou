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
    public partial class LoginUI : ContentPage
    {
        
        public LoginUI()
        {
            InitializeComponent();            
        }

        private async void Login_Button_Clicked(object sender, EventArgs e)
        {
            if(txtUsername.Text == "mike" && txtPassword.Text == "123")
            {
                await Navigation.PushAsync(new HomePage(), true);                    
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage(), true);
        }
    }
}