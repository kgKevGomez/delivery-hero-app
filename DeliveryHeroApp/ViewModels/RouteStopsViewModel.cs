using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DeliveryHeroApp.Core;

namespace DeliveryHeroApp.ViewModels
{
    public class RouteStopsViewModel : BaseViewModel
    {
        private readonly IDataStore<RouteStop> routeStopsStore;

        public ObservableCollection<RouteStop> RouteStops { get; set; } = new ObservableCollection<RouteStop>();

        public RouteStopsViewModel(IDataStore<RouteStop> routeStopsStore)
        {
            this.routeStopsStore = routeStopsStore;
        }

        public async Task FetchRouteStops()
        {
            IsBusy = true;
            RouteStops = new ObservableCollection<RouteStop>(await routeStopsStore.GetRouteStops());

            IsBusy = false;
        }
    }
}
