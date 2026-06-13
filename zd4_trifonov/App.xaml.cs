using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using zd4_trifonov.Services;
using zd4_trifonov.Views;

namespace zd4_trifonov
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            var navPage = new NavigationPage(new zd4_trifonov.Views.WelcomePage());
            navPage.BarBackgroundColor = Color.FromHex("#2D3035");
            navPage.BarTextColor = Color.FromHex("#E91E63");
            MainPage = navPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
