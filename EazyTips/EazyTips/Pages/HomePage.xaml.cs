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
            return Regex.Match(Phone, @"^([7]\d{10}$)").Success;
        }

        private static bool isEmailValid(string Email)
        {
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.
                        [0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            return regex.Match(Email).Success;
            /*try
            {
                MailAddress mailAddress = new MailAddress(Email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }*/
        }
    }
}