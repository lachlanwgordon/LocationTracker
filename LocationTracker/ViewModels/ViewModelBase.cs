using System.ComponentModel;
using System.Diagnostics;
using Prism.Mvvm;
using Prism.Navigation;

namespace LocationTracker.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible, INotifyPropertyChanged    {        protected INavigationService NavigationService { get; private set; }        public string Title { get; set; }        public ViewModelBase(INavigationService navigationService)        {            NavigationService = navigationService;        }        public virtual void OnNavigatedFrom(INavigationParameters parameters)        {            Debug.WriteLine("Hello4");        }        public virtual void OnNavigatedTo(INavigationParameters parameters)        {            Debug.WriteLine("Hello3");        }        public virtual void OnNavigatingTo(INavigationParameters parameters)        {            Debug.WriteLine("Hello2");        }        public virtual void Destroy()        {            Debug.WriteLine("Hello1");        }    }
}
