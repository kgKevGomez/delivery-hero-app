using System;
using DeliveryHeroApp.Core;
using DeliveryHeroApp.ViewModels;
using Xamarin.Forms;

namespace DeliveryHeroApp.Views
{
    [QueryProperty("RouteId", "routeId")]
    public partial class RouteStopDetailsPage : ContentPage
    {
        public string RouteId {
            get => routeId;
            set => routeId = Uri.UnescapeDataString(value); //Unable to bind to long directly????
        }

        private RouteStopDetailsViewModel viewModel;
        private string routeId;

        public RouteStopDetailsPage()
        {
            InitializeComponent();

            viewModel = new RouteStopDetailsViewModel(new MockRouteStopsDataStore());
        }

        async void ContentPage_Appearing(object sender, EventArgs e)
        {
            if (routeId != null)
                await viewModel.LoadRouteDetails(long.Parse(routeId));
        }

    }
}
