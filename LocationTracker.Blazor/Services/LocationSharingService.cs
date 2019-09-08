using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using LocationTracker.Core;
using LocationTracker.Core.Interfaces;

namespace LocationTracker.Blazor.Services
{
    public class LocationSharingService : ILocationSharingService
    {
        public LocationSharingService()
        {
        }

        public string GetImplementationName()
        {
            return "LocationSharingService Implemented in blazor project";
        }

        public void Subscribe(ObservableCollection<Location> locations)
        {
        }

        public async Task Transmit(Location location)
        {
        }

        public void UnSubscribe(ObservableCollection<Location> locations)
        {
        }
    }
}
