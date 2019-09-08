using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LocationTracker.Views;
using Prism.DryIoc;
using Prism;
using Prism.Ioc;
using LocationTracker.ViewModels;
using LocationTracker.Pages;
using LocationTracker.Services;
using LocationTracker.Core;
using LocationTracker.Core.Interfaces;

namespace LocationTracker
{
    public partial class App : PrismApplication
    {

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("NavigationPage/AboutPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<AboutPage, AboutViewModel>();
            containerRegistry.RegisterForNavigation<MapPage, MapViewModel>();

            containerRegistry.RegisterSingleton<ILocationService, LocationService>();
            containerRegistry.RegisterSingleton<ILocationSharingService, LocationSharingService>();
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
