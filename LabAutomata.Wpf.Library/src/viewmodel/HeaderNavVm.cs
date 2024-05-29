using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.data_structures;
using Microsoft.Extensions.Logging;
using System.Text;

namespace LabAutomata.Wpf.Library.viewmodel {
    /// <summary>
    /// Represents the view model for the header navigation in the MVVM pattern.
    /// </summary>
    public class HeaderNavVm : Base {

        /// <summary>
        /// Gets the command for changing the current view model.
        /// </summary>
        public Command? ChangeVm {
            get => _changeVm;
            private set {
                _changeVm = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the sub current view model.
        /// </summary>
        public Base? SubCurrentVm {
            get => _subCurrentVm;
            set {
                _subCurrentVm = value;
                NotifyPropertyChanged();
            }
        }

        private Base? _currentVm;
        private Command? _changeVm;

        /// <summary>
        /// Gets or sets the current view model.
        /// </summary>
        public Base? CurrentVm {
            get => _currentVm;
            set {
                _currentVm = value;
                NotifyPropertyChanged();
                ChangeVm?.RaiseCanExecuteChanged();
                NotifyPropertyChanged(nameof(SubCurrentVm));
            }
        }

        /// <summary>
        /// Loads the initial state of the view model.
        /// </summary>
        public override void Load () {
            // TODO: could refactor this into its own class
            ChangeVm = new Command(vmIdObj => {
                if (vmIdObj == null || vmIdObj is not string)
                    return;

                _sb.Clear();
                var vmId = (string)vmIdObj;

                _sb.Append(vmId.Remove(vmId.Length - 2));
                _sb.Append(SubVmSuffix);

                SubCurrentVm = _vmc.Get(_sb.ToString());    // set SubCurrentVm first -> 
                CurrentVm = _vmc.Get(vmId);
            });

            CurrentVm = _vmc.Get(nameof(HomeVm));
        }

        private const string SubVmSuffix = "ContentVm";
        private readonly StringBuilder _sb = new();
        private Base? _subCurrentVm;


        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderNavVm"/> class.
        /// </summary>
        /// <param name="logger">Optional logger.</param>
        public HeaderNavVm (IVmc vmc, ILogger? logger = default) : base(logger, true) {
            _vmc = vmc;
        }

        private readonly IVmc _vmc;
    }
}
