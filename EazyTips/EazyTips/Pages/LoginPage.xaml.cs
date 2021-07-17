using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EazyTips.Repository;
using EazyTips.Client;
using System.Threading.Tasks;

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
            if (!string.IsNullOrEmpty(LoginPhone.Text) || !string.IsNullOrEmpty(LoginPassword.Text))
            {
                string _phone = LoginPhone.Text.ToString();
                if (User.isPhoneValid(_phone))
                {
                    LoginService loginService = new LoginService();
                    int GetUserId = -1;
                    GetUserId = await loginService.CheckLoginIfExists(LoginPhone.Text.ToString(), LoginPassword.Text);
                    if (GetUserId != -1)
                    {
                        await Navigation.PushAsync(new HomePage(GetUserId));
                    }
                    else
                    {
                        await DisplayAlert("Login failed", "Phone or Password is incorrect or not exists", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Enter Data", "Enter correct phone number", "OK");
                }
            }
            else
            {
                await DisplayAlert("Enter Data", "Enter Phone Number and Password", "OK");
            }
        }

        private void FocuseNext()
        {
            LoginPhone.ReturnCommand = new Command(() => LoginPassword.Focus());
        }
    }
}