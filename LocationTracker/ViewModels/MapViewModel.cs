using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using LocationTracker.Core;
using LocationTracker.Core.Interfaces;
using LocationTracker.Services;
using Prism.Navigation;

namespace LocationTracker.ViewModels
{
    public class MapViewModel : ViewModelBase
    {
        ILocationService LocationService;
        ILocationSharingService LocationSharingService;

        Location myLocation;
        public Location MyLocation
        {
            get
            {
                return myLocation;
            }
            set
            {
                myLocation = value;
                TransmitLocation();
            }
        }

        private async void TransmitLocation()
        {
            MyLocation.Name = "Lachlan";
            await LocationSharingService.Transmit(MyLocation);
        }

        public ObservableCollection<Location> Locations { get; } = new ObservableCollection<Location>();

        public MapViewModel(INavigationService navigationService, ILocationService locationService, ILocationSharingService locationSharingService) : base(navigationService)
        {
            LocationService = locationService;
            LocationSharingService = locationSharingService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Debug.WriteLine("Hello5");
            LocationService.Subscribe(this, nameof(MyLocation));
            LocationSharingService.Subscribe(Locations);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
            LocationService.Unsubscribe(this);
            LocationSharingService.UnSubscribe(Locations);
        }
    }
}
