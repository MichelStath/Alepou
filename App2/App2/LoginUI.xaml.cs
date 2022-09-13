using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;
using System.IO;
using App2.Tables;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUI : ContentPage
    {
        
        public LoginUI()
        {
            InitializeComponent();
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
       
        async void Login_Button_Clicked(object sender, EventArgs e)
        {           
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);

            var myquerry = db.Table<RegUserTable>().Where(u => u.UserName.Equals(txtUsername.Text) && u.Password.Equals(txtPassword.Text)).FirstOrDefault();
            if (myquerry != null)
            {
                await Navigation.PushAsync(new HomePage(txtUsername.Text), true);
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