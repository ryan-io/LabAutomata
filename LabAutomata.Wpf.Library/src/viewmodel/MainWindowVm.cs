﻿using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.data_structures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Windows.Threading;

namespace LabAutomata.Wpf.Library.viewmodel {
    public class MainWindowVm : Base {
        public CommandAsync ChangeVm { get; }

        private Base? _currentVm;

        public Base? CurrentVm {
            get => _currentVm;
            set {
                _currentVm = value;
                NotifyPropertyChanged();
                ChangeVm.RaiseCanExecuteChanged();
            }
        }

        public MainWindowVm (IServiceProvider sp) : base(sp) {
            var da = sp.GetService<IAdapter<Dispatcher>>();
            var l = sp.GetService<ILogger>();

            // 1. The method creates a new instance of the `ViewModelCollection` named `_vms`.
            // 2. It uses the `ServiceProvider` to retrieve instances of the view models (`HomeVm`, `NavigationVm`, `WorkRequestVm`, `CreateWorkRequestVm`) and adds them to the `_vms` collection.
            // 3. It creates a `HashSet<Task>` named `bag` to store the tasks for loading the view models.
            // 4. It iterates over each view model in the `_vms` collection and adds the corresponding `LoadAsync()` task to the `bag`.
            // 5. It awaits the completion of all the tasks in the `bag` using `Task.WhenAll()`.
            //
            // - This method is called during the initialization of the `MainWindowVm` class to load the required view models.
            _vms = new ViewModelCollection
            {
                { nameof(HomeVm), ServiceProvider.GetService<HomeVm>()! },
                { nameof(NavigationVm), ServiceProvider.GetService<NavigationVm>()! },
                { nameof(WorkRequestVm), ServiceProvider.GetService<WorkRequestVm>()! },
                { nameof(CreateWorkRequestVm), ServiceProvider.GetService<CreateWorkRequestVm>()! },
            };

            ChangeVm = new CommandAsync(da!.Get(), l!, async newVm => {
                await Task.Delay(3000);
                CurrentVm = _vms[(newVm as string)!];
            });
        }

        private ViewModelCollection _vms;
        private const string NullVmColString =
            "Viewmodel collection was not found or was set to null in the service provider";
    }
}