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

            //Turns out that relative routes and passing parameters is not supported when Forms < 4.7 ?
            //Instead an absolute route must be used but that will replace navigation stack
            await Shell.Current.GoToAsync($"RouteStopDetails?routeId={routeStop.Id}");

            RouteStopsListView.SelectedItem = null;
        }

        async void ContentPage_Appearing(object sender, System.EventArgs e)
        {
            await viewModel.FetchRouteStops(); //Proper place to invoke async loading methods?
        }
    }
}
