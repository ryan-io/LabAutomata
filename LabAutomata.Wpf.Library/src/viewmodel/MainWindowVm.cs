using LabAutomata.Wpf.Library.commands;
using LabAutomata.Wpf.Library.data_structures;
using Microsoft.Extensions.Logging;
using System.Windows.Input;

namespace LabAutomata.Wpf.Library.viewmodel {
    public class MainWindowVm : Base {
        public ICommand CloseCmd { get; set; }

        public Base? NavVm {
            get => _navVm;
            private set {
                _navVm = value;
                NotifyPropertyChanged();
            }
        }

        public Base? FocusedVm {
            get => _focusedVm;
            set {
                _focusedVm = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(SubFocusedVm));
            }
        }

        public Base? MainNavVm {
            get => _headerNavVm;
            set {
                _headerNavVm = value;
                NotifyPropertyChanged();
            }
        }

        public Base? SubFocusedVm { get; set; }

        public override void Load () {
            FocusedVm = Vmc.Instance[nameof(HomeVm)];
            SubFocusedVm = Vmc.Instance[nameof(HomeContentVm)];
            NavVm = Vmc.Instance[nameof(NavigationVm)];
            MainNavVm = Vmc.Instance[nameof(HeaderNavVm)];

            if (MainNavVm == null) throw new NullReferenceException(NullMwVm);

            // sender in this instance is assumed to be the NavigationVm
            MainNavVm.PropertyChanged += (sender, args) => {
                if (sender is not HeaderNavVm mainVm)
                    return;

                FocusedVm = mainVm.CurrentVm;
                SubFocusedVm = mainVm.SubCurrentVm;
            };
        }

        public MainWindowVm (NavigationVm nvm, HomeVm hvm, HomeContentVm hcvm,
            ILogger? logger = default) : base(logger, true) {
            NavVm = nvm;
            FocusedVm = hvm;
            SubFocusedVm = hcvm;
            CloseCmd = new CloseAppCmd();
        }

        private Base? _focusedVm;
        private Base? _navVm;
        private Base? _headerNavVm;

        private const string NullMwVm = "Main window viemwodel cannot be null.";
    }
}