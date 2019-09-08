using LocationTracker.Blazor.Services;
using LocationTracker.Blazor.ViewModels;
using LocationTracker.Core.Interfaces;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;

namespace LocationTracker.Blazor
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MapPageViewModel>();
            services.AddScoped<IEventAggregator, EventAggregator>();
            services.AddSingleton<ILocationSharingService, LocationSharingService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
