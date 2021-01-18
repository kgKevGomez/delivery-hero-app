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
        private ObservableCollection<RouteStop> routeStops;

        public ObservableCollection<RouteStop> RouteStops
        {
            get { return routeStops; }
            set
            {
                SetProperty(ref routeStops, value);
            }
        }

        public RouteStopsViewModel(IDataStore<RouteStop> routeStopsStore)
        {
            routeStops = new ObservableCollection<RouteStop>();
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
