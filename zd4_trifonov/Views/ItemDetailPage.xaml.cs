using System.ComponentModel;

using Xamarin.Forms;

using zd4_trifonov.ViewModels;

namespace zd4_trifonov.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}