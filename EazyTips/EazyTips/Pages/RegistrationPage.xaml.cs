using EazyTips.Client;
using EazyTips.Repository;
using System;
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
            if (string.IsNullOrEmpty(SignUpPhone.Text) || string.IsNullOrEmpty(SignUpPassword.Text))
            { 
                await DisplayAlert("Enter Data", "Enter Valid Data", "OK");
            }
            else if (!string.Equals(SignUpPassword.Text, confirmpasswordEntry.Text)) 
            {
                warningLabel.Text = "Enter Same Password";
                SignUpPassword.Text = string.Empty;
                confirmpasswordEntry.Text = string.Empty;
                warningLabel.IsVisible = true;
            }
            else if (SignUpPhone.Text.Length < 11)
            {
                SignUpPhone.Text = string.Empty;
                warningLabel.Text = "Enter 11 digit Number";
                warningLabel.IsVisible = true;
            }
            else
            {
                string _phone = Convert.ToString(SignUpPhone.Text);
                string _password = Convert.ToString(SignUpPassword.Text);
                if (!User.isPhoneValid(_phone))
                {
                    await DisplayAlert("Enter Data", "Enter correct phone number", "OK");
                    return;
                }

                try
                {
                    LoginService service = new LoginService();
                    int GetUserId = -1;
                    GetUserId = Convert.ToInt32(await service.CheckLoginIfExists(_phone, _password));
                    if (GetUserId != -1)
                    {
                        await DisplayAlert("Registration Failed", " Already have an account", "OK");
                        return;
                    }

                    RegistrationService registrationService = new RegistrationService();
                    bool RegistrationSuccess = await registrationService.RegistrationSuccess(_phone, _password);
                    if (RegistrationSuccess)
                    {
                        await Navigation.PushAsync(new LoginPage());
                    }
                    else
                    {
                        await DisplayAlert("Registration Failed", "Wrong input", "OK");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Registration failed", ex.Message, "OK");
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
    }
}