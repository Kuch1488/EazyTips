using EazyTips.Client;
using EazyTips.Entetys;
using EazyTips.Repository;
using System;
using System.Collections.Generic;
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
        public User user { get; set; }
        public List<Card> cards { get; set; }
        public HomePage(int ID)
        {
            InitializeComponent();
            BindingContext = this;

            NavigationPage.SetHasNavigationBar(this.Home, false);

            user = new User();
            user = GetUserData(ID);
            cards = new List<Card>();
            cards = GetCards(ID);
        }

        protected override void OnAppearing()
        {
            UserUrl.Text = $"https://eazytips.ml/pay/{user.Id}";
            Url.CommandParameter = $"https://eazytips.ml/pay/{user.Id}";
            UserQrCode.BarcodeValue = $"https://eazytips.ml/pay/{user.Id}";
            if(user.Name != null)
            {
                UserName.Text = user.Name;
                ProfelName.Text = user.Name;
            }

            foreach (Card card in cards)
            {
                CardNumber.Text = card.Number;
                ValidThru.Text = Convert.ToDateTime(card.Valid).ToString("MM/yy").Replace('.', '/');
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

        private User GetUserData(int UserId)
        {
            UserService service = new UserService();
            Task<User> user = Task.Run(async () => await service.GetUserAsync(UserId));
            return user.Result;
        }

        public ICommand ClickCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        private async void ChangeData_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserEdiit(user));
        }
    }
}