using DeliveryHeroApp.Core;
using Xamarin.Forms;

namespace DeliveryHeroApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<IRouteStopsDataStore<RouteStop>,MockDataStore>();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
