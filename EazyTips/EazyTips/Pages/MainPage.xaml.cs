using EazyTips.Pages;
using System;
using Xamarin.Forms;

namespace EazyTips
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this.FirstPage, true);
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}
