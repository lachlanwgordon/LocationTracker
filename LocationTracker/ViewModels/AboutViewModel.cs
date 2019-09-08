using Prism.Commands;using Prism.Mvvm;using Prism.Navigation;using System;using System.Collections.Generic;using System.Linq;using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LocationTracker.ViewModels
{
    public class AboutViewModel  : ViewModelBase    {        public AboutViewModel(INavigationService navigationService): base(navigationService)        {            Title = "Main Page";        }        private DelegateCommand openMapCommand;        public DelegateCommand OpenMapCommand => openMapCommand ?? new DelegateCommand(ExecuteOpenMapCommand);        public async void ExecuteOpenMapCommand()
        {
            await NavigationService.NavigateAsync("NavigationPage/MapPage");
        }    }
}