using EazyTips.Client;
using EazyTips.Repository;
using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EazyTips.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public User User { get; set; }
        public HomePage(User user)
        {
            InitializeComponent();
           
            NavigationPage.SetHasNavigationBar(this.Home, false);
            User = user;
        }

        protected override void OnAppearing()
        {
            UserQrCode.BarcodeValue = $"http://0ceccd8d7b41.ngrok.io/api/user/{User.Id}";
            if(User.Name != null)
            {
                UserName.Text = User.Name;
            }
        }

        private async void Exit_ButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}