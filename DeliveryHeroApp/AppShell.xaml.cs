using DeliveryHeroApp.Views;
using Xamarin.Forms;

namespace DeliveryHeroApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RouteStopsPage), typeof(RouteStopsPage));
        }

    }
}
