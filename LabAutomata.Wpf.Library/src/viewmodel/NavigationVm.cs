using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.data_structures;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Threading;

namespace LabAutomata.Wpf.Library.viewmodel {
    /// <summary>
    /// Represents a view model for navigation within the application.
    /// </summary>
    public class NavigationVm : Base {
        /// <summary>
        /// Gets the command ID for the work request view model.
        /// </summary>
        public string CmdIdWorkRequest { get; } = nameof(WorkRequestVm);

        /// <summary>
        /// Gets the command for changing the current view model.
        /// </summary>
        public CommandAsync ChangeVm { get; }

        private Base? _currentVm;

        /// <summary>
        /// Gets or sets the current view model.
        /// </summary>
        public Base? CurrentVm {
            get => _currentVm;
            set {
                _currentVm = value;
                NotifyPropertyChanged();
                ChangeVm.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationVm"/> class.
        /// </summary>
        /// <param name="sp">The service provider.</param>
        /// <param name="vmc">The view model collection.</param>
        public NavigationVm (IServiceProvider sp, ViewModelCollection vmc) : base(sp) {
            _vmc = vmc;
            var da = sp.GetService<IAdapter<Dispatcher>>();

            if (da == null)
                throw new NullReferenceException(DispatcherNull);

            // TODO: could refactor this into its own class
            ChangeVm = new CommandAsync(da.Get(), async vmIdObj => {
                if (vmIdObj == null || vmIdObj is not string)
                    return;

                await Task.Delay(3000);
                CurrentVm = _vmc[(string)vmIdObj];
            });
        }

        private readonly ViewModelCollection _vmc;
        private const string DispatcherNull = "Dispatcher adapter was null.";
    }
}