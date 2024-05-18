using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.data_structures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Windows.Threading;

namespace LabAutomata.Wpf.Library.viewmodel {
    public class NavigationVm : Base {
        public string CmdIdWorkRequest { get; } = nameof(WorkRequestVm);

        public Command ChangeVm { get; }

        private Base? _currentVm;

        public Base? CurrentVm {
            get => _currentVm;
            set {
                _currentVm = value;
                NotifyPropertyChanged();
                ChangeVm.RaiseCanExecuteChanged();
            }
        }

        public NavigationVm (IServiceProvider sp, ViewModelCollection vmc) : base(sp) {
            _vmc = vmc;
            var da = sp.GetService<IAdapter<Dispatcher>>();

            //ChangeVm = new CommandAsync(da!.Get(), context: async newVm => {
            //    Logger?.LogInformation("ChangeVm command heard!");
            //    Logger?.LogInformation("Command passed: " + newVm);
            //    await Task.Delay(3000);
            //    var t = _vmc[(newVm as string)!];
            //    CurrentVm = t;
            //});

            ChangeVm = new Command(newVm => {
                Logger?.LogInformation("ChangeVm command heard!");
                Logger?.LogInformation("Command passed: " + newVm);
                //await Task.Delay(3000);
                var t = _vmc[newVm as string];
                CurrentVm = t;
            });
        }

        private readonly ViewModelCollection _vmc;
    }
}
