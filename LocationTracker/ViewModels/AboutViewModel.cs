﻿using Prism.Commands;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LocationTracker.ViewModels
{
    public class AboutViewModel  : ViewModelBase
        {
            await NavigationService.NavigateAsync("NavigationPage/MapPage");
        }
}