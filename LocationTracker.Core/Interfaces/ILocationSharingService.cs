using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace LocationTracker.Core.Interfaces
{
    public interface ILocationSharingService
    {
        void Subscribe(ObservableCollection<Location> locations);
        void UnSubscribe(ObservableCollection<Location> locations);
        Task Transmit(Location location);
        string GetImplementationName();
    }
}
