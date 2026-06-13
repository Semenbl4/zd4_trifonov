using System;
using System.Collections.Generic;

using Xamarin.Forms;

using zd4_trifonov.ViewModels;
using zd4_trifonov.Views;

namespace zd4_trifonov
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
