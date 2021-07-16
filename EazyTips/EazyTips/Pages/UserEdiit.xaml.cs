using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EazyTips.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserEdiit : ContentPage
    {
        public UserEdiit()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this.UserData, false);
        }

        private void Edit_Clicked(object sender, EventArgs e)
        {

        }

        private void Save_Button(object sender, EventArgs e)
        {

        }
    }
}