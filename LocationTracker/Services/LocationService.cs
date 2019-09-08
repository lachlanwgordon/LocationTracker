using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using LocationTracker.Core;
using LocationTracker.Core.Interfaces;
using LocationTracker.ViewModels;
using Xamarin.Forms.Internals;

namespace LocationTracker.Services
{
    public class LocationService : ILocationService
    {
        private const int LocationFrequencyInMillis = 2000;
        bool isRunning;

        public LocationService()
        {
            Debug.WriteLine("Location init");
        }

        Dictionary<object, string> SubscribedLocations { get; } = new Dictionary<object, string>();

        public void Subscribe(object owner, string propertyName)
        {
            SubscribedLocations.Add(owner, propertyName);
            UpdateLocation();
        }


        private bool UpdateLocation()
        {
            if(SubscribedLocations.Count == 0)
            {
                return false;
            }
            if(isRunning)
            {
                return false;
            }
            isRunning = true;

            Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(async () =>
            {

                var location = await Xamarin.Essentials.Geolocation.GetLocationAsync(new Xamarin.Essentials.GeolocationRequest(Xamarin.Essentials.GeolocationAccuracy.High, TimeSpan.FromMilliseconds(1000)));
                if (location != null)
                {
                    var loc = new LocationTracker.Core.Location(location.Latitude, location.Longitude);

                    SubscribedLocations.ForEach(x => x.Key.GetType().GetProperty(x.Value).SetValue(x.Key, loc));//This needs some type checking incase someone passes in a field that isn't a location
                }
                else
                {
                    Debug.WriteLine("Couldn't find location");
                }
                isRunning = false;
                Xamarin.Forms.Device.StartTimer(TimeSpan.FromMilliseconds(LocationFrequencyInMillis), UpdateLocation);
            });

            return false;
        }

        public void Unsubscribe(object owner)
        {
            SubscribedLocations.Remove(owner);
        }
    }
}
