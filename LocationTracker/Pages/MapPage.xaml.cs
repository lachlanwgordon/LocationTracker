using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using LocationTracker.Core;
using LocationTracker.ViewModels;
using Xamarin.Forms;

namespace LocationTracker.Pages
{
    public partial class MapPage : ContentPage
    {
        MapViewModel Vm => BindingContext as MapViewModel;
        public MapPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Vm.Locations.CollectionChanged += LocationsChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Vm.Locations.CollectionChanged -= LocationsChanged;
        }

        private async void LocationsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var newItems = new List<Location>();

            if (e.NewItems?.Count > 0)
            {

                foreach (var item in e.NewItems)
                {
                    var loc = item as Location;
                    newItems.Add(loc);
                }

                var minLat = Vm.Locations.OrderBy(x => x.Latitude).FirstOrDefault().Latitude;
                var maxLat = Vm.Locations.OrderByDescending(x => x.Latitude).FirstOrDefault().Latitude;
                var minLon = Vm.Locations.OrderBy(x => x.Longitude).FirstOrDefault().Longitude;
                var maxLon = Vm.Locations.OrderByDescending(x => x.Longitude).FirstOrDefault().Longitude;
                var update = Xamarin.Forms.GoogleMaps.CameraUpdateFactory.NewBounds(new Xamarin.Forms.GoogleMaps.Bounds(new Xamarin.Forms.GoogleMaps.Position(minLat, minLon), new Xamarin.Forms.GoogleMaps.Position(maxLat, maxLon)), 50);
                await TheMap.AnimateCamera(update, TimeSpan.FromMilliseconds(100));
            }
        }
    }
}
