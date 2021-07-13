using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EazyTips.Repository;
using EazyTips.Client;

namespace EazyTips.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            FocuseNext();
        }

        private async void LoginValidation_ButtonClicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(LoginPhone.Text) || string.IsNullOrEmpty(LoginPassword.Text))
            {
                await DisplayAlert("Enter Data", "Enter Phone Number and Password", "OK");
                return;
            }
            string _phone = LoginPhone.Text.ToString();
            if (User.isPhoneValid(_phone))
            {
                LoginService loginService = new LoginService();
                bool GetLoginDetails = await loginService.CheckLoginIfExists(LoginPhone.Text.ToString(), LoginPassword.Text);

                if (GetLoginDetails)
                {
                    await Navigation.PushAsync(new HomePage());
                }
                else
                {
                    await DisplayAlert("Login failed", "Phone or Password is incorrect or not exists", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Enter Data", "Enter correct phone number", "OK");
            }
        }

        private void FocuseNext()
        {
            LoginPhone.ReturnCommand = new Command(() => LoginPassword.Focus());
        }
    }
}