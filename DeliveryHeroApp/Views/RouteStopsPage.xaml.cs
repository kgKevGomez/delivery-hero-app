using DeliveryHeroApp.Core;
using DeliveryHeroApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliveryHeroApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RouteStopsPage : ContentPage
    {
        private RouteStopsViewModel viewModel { get; }

        public RouteStopsPage()
        {
            InitializeComponent();

            viewModel = new RouteStopsViewModel(new MockRouteStopsDataStore());

            BindingContext = viewModel;
        }

        async void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is RouteStop routeStop))
                return;

            await Navigation.PushAsync(new RouteStopDetailsPage(routeStop.Id));

            RouteStopsListView.SelectedItem = null;
        }

        async void ContentPage_Appearing(object sender, System.EventArgs e)
        {
            await viewModel.FetchRouteStops(); //Proper place to invoke async loading methods?
        }
    }
}
