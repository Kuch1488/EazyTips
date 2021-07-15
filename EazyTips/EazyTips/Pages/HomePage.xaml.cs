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
        public int Id { get; set; }
        public HomePage(User user, int id)
        {
            InitializeComponent();
           
            NavigationPage.SetHasNavigationBar(this.Home, false);
            User = user;
            Id = id;
        }

        protected override void OnAppearing()
        {
            UserUrl.Text = $"https://eazytips.ml/pay/{Id}";
            UserQrCode.BarcodeValue = $"https://eazytips.ml/pay/{Id}";
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