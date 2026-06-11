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

            DependencyService.Register<MockDataStore>();
            MainPage = new zd4_trifonov.Views.TabbedPage1();
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
