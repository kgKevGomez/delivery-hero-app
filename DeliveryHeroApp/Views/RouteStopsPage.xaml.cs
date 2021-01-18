using DeliveryHeroApp.Core;
using DeliveryHeroApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliveryHeroApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RouteStopsPage : ContentPage
    {
        public RouteStopsViewModel ViewModel { get; }

        public RouteStopsPage()
        {
            InitializeComponent();

            ViewModel = new RouteStopsViewModel(new MockDataStore());

            BindingContext = ViewModel;
        }

        async void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            RouteStopsListView.SelectedItem = null;
        }

        async void ContentPage_Appearing(object sender, System.EventArgs e)
        {
            await ViewModel.FetchRouteStops(); //Proper place to invoke async loading methods?
        }
    }
}
