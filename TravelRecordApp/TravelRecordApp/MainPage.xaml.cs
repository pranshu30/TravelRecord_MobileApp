using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);

            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.plane.png", assembly);

        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool canlogin = await User.Login(EmailEntry.Text, PasswordEntry.Text);


            if (canlogin)
            {
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Error", "Try again", "Ok");


            }

        }

        private void RegisteruserButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());

        }
    }
}
