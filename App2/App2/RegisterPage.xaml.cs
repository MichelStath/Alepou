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
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection (dbpath);
            db.CreateTable<RegUserTable>();
            var item = new RegUserTable()
            {
                UserName = txtUsername.Text,
                Password = txtPassword.Text
            };

            db.Insert(item);

        }

        private async void GoToLoginPage_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginUI(), true);
        }
    }
}