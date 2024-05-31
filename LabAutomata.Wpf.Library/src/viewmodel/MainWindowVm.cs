﻿using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.commands;
using LabAutomata.Wpf.Library.data_structures;
using Microsoft.Extensions.Logging;
using System.Windows.Input;
using System.Windows.Threading;

namespace LabAutomata.Wpf.Library.viewmodel {
    public class MainWindowVm : Base {
        public ICommand CloseCmd { get; set; }
        public ICommand LoadedCmd { get; set; }

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
            FocusedVm = _vmc.Get(nameof(HomeVm));
            SubFocusedVm = _vmc.Get(nameof(HomeContentVm));
            NavVm = _vmc.Get(nameof(NavigationVm));
            MainNavVm = _vmc.Get(nameof(HeaderNavVm));

            if (MainNavVm == null) throw new NullReferenceException(NullMwVm);

            // sender in this instance is assumed to be the NavigationVm
            MainNavVm.PropertyChanged += (sender, args) => {
                if (sender is not HeaderNavVm mainVm)
                    return;

                FocusedVm = mainVm.CurrentVm;
                SubFocusedVm = mainVm.SubCurrentVm;
            };
        }

        public MainWindowVm (IVmc vmc, IAdapter<Dispatcher> da, NavigationVm nvm, HomeVm hvm, HomeContentVm hcvm,
            ILogger? logger = default) : base(logger, true) {
            NavVm = nvm;
            FocusedVm = hvm;
            SubFocusedVm = hcvm;
            CloseCmd = new CloseAppCmd();
            LoadedCmd = new ApplicationEntryCommand(vmc, da, logger);
            _vmc = vmc;
        }

        private Base? _focusedVm;
        private Base? _navVm;
        private Base? _headerNavVm;

        private const string NullMwVm = "Main window viemwodel cannot be null.";
        private readonly IVmc _vmc;
    }
}