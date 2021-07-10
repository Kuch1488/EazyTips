using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EazyTips.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this.Home, false);
        }

        private async void Exit_ButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private static bool isPhoneValid(string Phone)
        {
            return Regex.Match(Phone, @"^\d{11}$").Success;
        }

        private static bool isEmailValid(string Email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(Email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}