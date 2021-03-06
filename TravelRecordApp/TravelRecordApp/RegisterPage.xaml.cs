﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        User user;
        public RegisterPage()
        {
            InitializeComponent();
            user = new User();

            containerStackLayout.BindingContext = user;
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            if(PasswordEntry.Text == ConfirmedPasswordEntry.Text)
            {
                /*
                 * Binding context no use of declaring the variable
                //register new user
                User user = new User
                {
                    Email = EmailEntry.Text,
                    Password = PasswordEntry.Text
                };
                //await App.MobileService.GetTable<User>().InsertAsync(user);
                */
                //MVVM
               User.Register(user);
               await DisplayAlert("Success", "User successfully added", "Ok");
            }
            else
            {
                await DisplayAlert("Error", "Password do not match", "Ok");
            }
        }
    }
}