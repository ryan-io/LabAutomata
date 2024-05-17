using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.data_structures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Windows.Threading;

namespace LabAutomata.Wpf.Library.viewmodel {
    public class MainWindowVm : Base {
        public string MainWindowVmName { get; set; } = nameof(MainWindowVm);

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
            _vms = new ViewModelCollection()
            {
                { nameof(MainWindowVm), this }
            };

            ChangeVm = new CommandAsync(da!.Get(), l!, async newVm => {
                await Task.Delay(3000);
                Logger?.LogInformation("View model changed!");
                CurrentVm = _vms![(newVm as string)!];
            });
        }

        private readonly ViewModelCollection _vms = new();

        private const string NullVmColString =
            "Viewmodel collection was not found or was set to null in the service provider";
    }
}
