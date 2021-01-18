using System.Threading.Tasks;
using DeliveryHeroApp.Core;

namespace DeliveryHeroApp.ViewModels
{
    public class RouteStopDetailsViewModel : BaseViewModel
    {
        private readonly IRouteStopsDataStore routeStopsDataStore;
        private RouteStop routeStop;

        public RouteStopDetailsViewModel(IRouteStopsDataStore routeStopsDataStore)
        {
            this.routeStopsDataStore = routeStopsDataStore;
        }

        public RouteStop RouteStop
        {
            get => routeStop;
            set => SetProperty(ref routeStop, value);
        }

        public async Task LoadRouteDetails(long id)
        {
            RouteStop = await routeStopsDataStore.GetRoute(id);
        }
    }
}
