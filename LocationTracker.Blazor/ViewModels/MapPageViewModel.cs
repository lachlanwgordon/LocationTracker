using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using LocationTracker.Blazor.Helpers;
using LocationTracker.Core;
using LocationTracker.Core.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace LocationTracker.Blazor.ViewModels
{
    public class MapPageViewModel : BindableBase
    {
        private ILocationSharingService LocationSharingService;
        private IEventAggregator EventAggregator;
        public ObservableCollection<Location> Locations { get; set; } = new ObservableCollection<Location>();

        public string Message { get; set; } = "I'm a view Model";

        public MapPageViewModel(ILocationSharingService locationSharingService, IEventAggregator ea)
        {
            LocationSharingService = locationSharingService;
            EventAggregator = ea;

            Init();
        }

        private DelegateCommand goCommand;
        public DelegateCommand GoCommand => goCommand ?? new DelegateCommand(ExecuteGoCommand);

        public void ExecuteGoCommand()
        {
            Message = "Go Clicked";
        }

        private async void Init()
        {
            var serviceName = LocationSharingService.GetImplementationName();
            Message = serviceName;


            Locations.Add(new Location(-37.1, 145.1) { Name = "Blazor" });
            await Task.Delay(2000);
            Locations.Add(new Location(-37.2, 145.2) { Name = "Blazor2" });
            await Task.Delay(2000);
            Locations.Add(new Location(-37.3, 145.3) { Name = "Blazor3" });
        }
    }
}
