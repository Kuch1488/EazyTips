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
        private static readonly HttpClient Client = new HttpClient();

        public LoginPage()
        {
            InitializeComponent();

            FocuseNext();
        }

        private async void LoginValidation_ButtonClicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(LoginPhone.Text) && !string.IsNullOrEmpty(LoginPassword.Text))
            {
                if(isPhoneVaild(LoginPhone.Text.ToString()))
                {
                    LoginService loginService = new LoginService();
                    bool GetLoginDetails = await loginService.CheckLoginIfExists(LoginPhone.Text.ToString(), LoginPassword.Text);

                    if(GetLoginDetails)
                    {
                        await Navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                        await DisplayAlert("Login failed", "Username or Password is incorrect or not exists", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Enter Data", "Enter correct phone number", "OK");
                }
            }
            else
            {
                await DisplayAlert("Enter Data", "Enter Phone Number and Password Please", "OK");
            }
        }

        private void FocuseNext()
        {
            LoginPhone.ReturnCommand = new Command(() => LoginPassword.Focus());
        }

        private static bool isPhoneVaild(string Phone)
        {
            return Regex.IsMatch(Phone, @"^\d{11}$");
        }
    }
}