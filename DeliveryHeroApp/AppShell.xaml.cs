using System;
using System.Collections.Generic;
using DeliveryHeroApp.ViewModels;
using DeliveryHeroApp.Views;
using Xamarin.Forms;

namespace DeliveryHeroApp
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
