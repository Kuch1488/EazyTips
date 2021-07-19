using EazyTips.Repository;
using System;
using EazyTips.Client;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace EazyTips.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserEdiit : ContentPage
    {
        public User user { get; set; }
        public UserEdiit(User _user)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this.UserData, true);

            user = new User();
            user = _user;

            FocuseNext();
        }

        protected override void OnAppearing()
        {
            SetDefaultValue();
            UserPhone.Text = user.Phone;
        }

        private void Edit_Clicked(object sender, EventArgs e)
        {
            EntryEnabled(true);
        }

        private async void Save_Button(object sender, EventArgs e)
        {
            UserService service = new UserService();

            user.Name = ProfelName.Text;
            user.FullName = FullName.Text;
            user.Email = UserEmail.Text;

            if (!string.IsNullOrEmpty(user.Email))
            {
                if (!User.isEmailValid(user.Email))
                {
                    await DisplayAlert("Wrong input", "Email is not valid", "OK");
                    return;
                }
            }
            else
            {
                user.Email = null;
            }

            if (string.IsNullOrEmpty(user.Name))
            {
                user.Name = null;
            }

            if (string.IsNullOrEmpty(user.FullName))
            {
                user.FullName = null;
            }

            bool EditSuccess = await service.EditUser(user);

            if (EditSuccess)
            {
                await DisplayAlert("Edit", "Edit success", "OK");
            }
            else
            {
                await DisplayAlert("Edit error", "Something wrong", "OK");
            }
        }

        private void EntryEnabled(bool Enabled)
        {
            ProfelName.IsEnabled = Enabled;
            FullName.IsEnabled = Enabled;
            UserEmail.IsEnabled = Enabled;
        }

        private void FocuseNext()
        {
            ProfelName.ReturnCommand = new Command(() => FullName.Focus());
            FullName.ReturnCommand = new Command(() => UserEmail.Focus());
        }

        private void Cancel_Button(object sender, EventArgs e)
        {
            SetDefaultValue();
            EntryEnabled(false);
        }

        private void SetDefaultValue()
        {
            ProfelName.Text = user.Name;
            FullName.Text = user.FullName;
            UserEmail.Text = user.Email;
        }
    }
}