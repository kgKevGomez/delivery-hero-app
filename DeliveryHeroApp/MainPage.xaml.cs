using System;
using DeliveryHeroApp.Views;
using Xamarin.Forms;

namespace DeliveryHeroApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RouteStopsPage());
        }
    }
}
