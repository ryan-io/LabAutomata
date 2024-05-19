using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.data_structures;
using System.Text;

namespace LabAutomata.Wpf.Library.viewmodel {
    /// <summary>
    /// Represents a view model for navigation within the application.
    /// </summary>
    public class NavigationVm : Base {
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

        public Base? SubCurrentVm { get; set; }

        private Base? _currentVm;
        private Command? _changeVm;

        //TODO: this can just as easily be made a string

        /// <summary>
        /// Gets or sets the current view model.
        /// </summary>
        public Base? CurrentVm {
            get => _currentVm;
            set {
                _currentVm = value;
                NotifyPropertyChanged();
                ChangeVm?.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationVm"/> class.
        /// </summary>
        /// <param name="sp">The service provider.</param>
        /// <param name="vmc">The view model collection.</param>
        public NavigationVm (IServiceProvider sp) : base(sp) { }

        public override void Load () {
            // TODO: could refactor this into its own class
            ChangeVm = new Command(vmIdObj => {
                if (vmIdObj == null || vmIdObj is not string)
                    return;

                _sb.Clear();
                var vmId = (string)vmIdObj;

                _sb.Append(vmId.Remove(vmId.Length - 2));
                _sb.Append(SubVmSuffix);

                CurrentVm = Vmc.Instance[vmId];
                SubCurrentVm = Vmc.Instance[_sb.ToString()];
            });

            CurrentVm = Vmc.Instance[nameof(HomeVm)];
        }

        private const string SubVmSuffix = "ContentVm";
        private readonly StringBuilder _sb = new();
    }
}