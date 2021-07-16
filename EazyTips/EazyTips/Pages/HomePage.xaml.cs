using EazyTips.Client;
using EazyTips.Entetys;
using EazyTips.Repository;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EazyTips.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public User User { get; set; }
        public int Id { get; set; }
        public List<Card> cards { get; set; }
        public HomePage(User user, int id)
        {
            InitializeComponent();
            BindingContext = this;

            NavigationPage.SetHasNavigationBar(this.Home, false);
            User = user;
            Id = id;

            cards = new List<Card>();
            cards = GetCards(Id);
        }

        protected override void OnAppearing()
        {
            UserUrl.Text = $"https://eazytips.ml/pay/{Id}";
            Url.CommandParameter = $"https://eazytips.ml/pay/{Id}";
            UserQrCode.BarcodeValue = $"https://eazytips.ml/pay/{Id}";
            if(User.Name != null)
            {
                UserName.Text = User.Name;
            }

            foreach (Card card in cards)
            {
                CardNumber.Text = card.Number;
                ValidThru.Text = Convert.ToDateTime(card.Valid).ToString("MM/yy");
                if (card.Virtual == 1)
                {
                    Balence.Text = Convert.ToString(card.Balance);
                }
            }
            
            
        }

        private async void Exit_ButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private List<Card> GetCards(int UserId)
        {
            CardService cardService = new CardService();
            Task<List<Card>> card = Task.Run(async () => await cardService.GetUserCards(UserId));
            return card.Result;
        }

        public ICommand ClickCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        private async void ChangeData_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserEdiit());
        }
    }
}