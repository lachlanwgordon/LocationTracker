using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LocationTracker.Core;
using LocationTracker.Core.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using Xamarin.Forms;

namespace LocationTracker.Services
{
    public class LocationSharingService: ILocationSharingService
    {
        private ObservableCollection<Location> Locations;

        public LocationSharingService()
        {
        }
        HubConnection hubConnection;


        public void Subscribe(ObservableCollection<Location> locations)
        {
            Initialize();

            Locations = locations;

        }

        private void Initialize()
        {
            if (hubConnection != null)
                return;
            hubConnection = new HubConnectionBuilder()
                .WithUrl(BaseUrl)
                .Build();

            hubConnection.On<Location>("newLocation", NewLocation);
            hubConnection.On<string, string>("newMessage", NewMessage);
            hubConnection.StartAsync();
        }

        private void NewMessage(string arg1, string arg2)
        {
            Debug.WriteLine($"{arg1} {arg2}"); 
        }

        private void NewLocation(Location location)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Locations.Add(location);

            });
        }

        public string BaseUrl { get; set; } = "https://locationtrackerfunctions20190908103338.azurewebsites.net//api";
        HttpClient Client = new HttpClient();
        public async Task Transmit(Location location)
        {
            var content = Newtonsoft.Json.JsonConvert.SerializeObject(location);            await Client.PostAsync($"{BaseUrl}/locations", new StringContent(content, Encoding.UTF8, "application/json"));
        }

        public void UnSubscribe(ObservableCollection<Location> locations)
        {
        }

        public string GetImplementationName()
        {
            throw new NotImplementedException();
        }
    }
}
