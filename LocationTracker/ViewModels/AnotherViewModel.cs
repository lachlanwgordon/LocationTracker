using System;
using LocationTracker.ViewModels;
using Prism.Navigation;

namespace LocationTracker.ViewModels
{
    public class AnotherViewModel : ViewModelBase
    {
        public AnotherViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}