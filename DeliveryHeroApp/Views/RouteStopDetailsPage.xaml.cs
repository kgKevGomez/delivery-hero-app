using System;
using DeliveryHeroApp.Core;
using DeliveryHeroApp.ViewModels;
using Xamarin.Forms;

namespace DeliveryHeroApp.Views
{
    public partial class RouteStopDetailsPage : ContentPage
    {
        private readonly long routeId;
        private RouteStopDetailsViewModel viewModel;

        public RouteStopDetailsPage(long routeId)
        {
            InitializeComponent();

            viewModel = new RouteStopDetailsViewModel(new MockRouteStopsDataStore());
            this.routeId = routeId;
        }

        async void ContentPage_Appearing(object sender, EventArgs e)
        {
            await viewModel.LoadRouteDetails(routeId);
        }

    }
}
