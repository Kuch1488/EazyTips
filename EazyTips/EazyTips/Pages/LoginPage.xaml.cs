using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            if(!string.IsNullOrEmpty(LoginPhone.Text) && !string.IsNullOrEmpty(LoginPassword.Text))
            {
                if(isPhoneVaild(LoginPhone.Text.ToString()))
                {
                    await Navigation.PushAsync(new HomePage());
                }
            }
            else
            {
                await DisplayAlert("Enter Data", "Enter User Name and Password Please", "OK");
            }
        }

        private void FocuseNext()
        {
            LoginPhone.ReturnCommand = new Command(() => LoginPassword.Focus());
        }

        private static bool isPhoneVaild(string Phone)
        {
            return Regex.Match(Phone, @"^(\+[0-9]{11})$").Success;
        }
    }
}