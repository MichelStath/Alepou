using App2.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
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
            var dbpath = Path.Combine((Environment.CurrentDirectory), "UserDatabase.db");
            var db = new SQLiteConnection (dbpath);
            db.CreateTable<RegUserTable>();

            var myquerry = db.Table<RegUserTable>().Where(u => u.UserName.Equals(txtUsername.Text)).FirstOrDefault();
            if (txtUsername.Text != null && txtPassword.Text != null) //space problem
            {               
                if (myquerry == null)
                {
                    var item = new RegUserTable()
                    {
                        UserName = txtUsername.Text,
                        Password = txtPassword.Text
                    };

                    db.Insert(item);
                    await DisplayAlert("Alert", "Register successful! \n" +
                                                "Username: " + txtUsername.Text + "\n" +
                                                "Password: " + txtPassword.Text, "OK");
                    await Navigation.PushAsync(new LoginUI(), true);
                }
                else
                {
                    await DisplayAlert("Alert", "Username already used. Pick another username or login", "OK");
                }
            }
            else
            {
                await DisplayAlert("Alert", "Username OR Password", "OK");
            }

        }

        private async void GoToLoginPage_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginUI(), true);
        }
    }
}