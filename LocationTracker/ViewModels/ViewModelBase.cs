﻿using System.ComponentModel;
using System.Diagnostics;
using Prism.Mvvm;
using Prism.Navigation;

namespace LocationTracker.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible, INotifyPropertyChanged
}