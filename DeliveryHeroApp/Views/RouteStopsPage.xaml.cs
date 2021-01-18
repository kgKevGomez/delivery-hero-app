using System.Collections.ObjectModel;
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
            ViewModel.FetchRouteStops().Wait(); //Proper place to invoke async loading methods?

            BindingContext = ViewModel;
        }


        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
