using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EazyTips.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();

            FocuseNext();
        }

        private async void SignupValidation_ButtonClicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(SignUpPhone.Text) || string.IsNullOrEmpty(SignUpPassword.Text))
            { 
                await DisplayAlert("Enter Data", "Enter Valid Data", "OK");
            }
            else if(!string.Equals(SignUpPassword.Text, confirmpasswordEntry.Text)) 
            {
                warningLabel.Text = "Enter Same Password";
                SignUpPassword.Text = string.Empty;
                confirmpasswordEntry.Text = string.Empty;
                warningLabel.IsVisible = true;
            }
            else if(SignUpPhone.Text.Length < 11)
            {
                SignUpPhone.Text = string.Empty;
                warningLabel.Text = "Enter 11 digit Number";
                warningLabel.IsVisible = true;
            }
            else
            {
                string _phone = SignUpPhone.Text.ToString();
                string _password = SignUpPassword.Text;
                if(isPhoneValid(_phone))
                {
                    await Navigation.PushAsync(new LoginPage());
                }
            }
        }

        private async void login_ClickedEvent(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private void FocuseNext()
        {
            SignUpPhone.ReturnCommand = new Command(() => SignUpPassword.Focus());
            SignUpPassword.ReturnCommand = new Command(() => confirmpasswordEntry.Focus());
        }

        private static bool isPhoneValid(string Phone)
        {
            return Regex.Match(Phone, @"^(\+[0-9]{11})$").Success;
        }
    }
}