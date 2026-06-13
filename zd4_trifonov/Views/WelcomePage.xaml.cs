using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd4_trifonov.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
	{
        public WelcomePage()
        {
            InitializeComponent();
        }

        private async void OnSignInClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameEntry.Text))
            {
                await DisplayAlert("Ошибка", "Введите фамилию в поле Имя пользователя", "ОК");
                return;
            }

            string lastName = UsernameEntry.Text;

            // Теперь переход идет на карусель с передачей фамилии!
            await Navigation.PushAsync(new TabbedPage1(lastName));
        }
    }
}