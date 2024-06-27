using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.data_structures;
using Microsoft.Extensions.Logging;

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

		public Base? SubCurrentVm {
			get => _subCurrentVm;
			set {
				_subCurrentVm?.Dispose();
				_subCurrentVm = value;
			}
		}

		private Base? _currentVm;
		private Command? _changeVm;

		//TODO: this can just as easily be made a string

		/// <summary>
		/// Gets or sets the current view model.
		/// </summary>
		public Base? CurrentVm {
			get => _currentVm;
			set {
				_currentVm?.Dispose();
				_currentVm = value;
				NotifyPropertyChanged();
				ChangeVm?.RaiseCanExecuteChanged();
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NavigationVm"/> class.
		/// </summary>
		/// <param name="vmc">A key-value collection containing all view models in the application</param>
		/// <param name="extractor">For handling creating key values of type string passed to a VMC</param>
		/// <param name="logger">Optional logger.</param>
		public NavigationVm (IVmc vmc, IVmIdExtractor extractor, ILogger? logger = default)
			: base(logger, true) {
			_vmc = vmc;
			_extractor = extractor;
		}

		public override void Load () {
			ChangeVm = new Command(ChangeViewModel);
			CurrentVm = _vmc.Get(nameof(HomeVm));
		}

		private void ChangeViewModel (object? obj) {
			if (obj is not string vmId)
				return;

			CurrentVm = _vmc.Get(vmId);
			SubCurrentVm = _vmc.Get(_extractor.Extract(vmId));
		}

		private readonly IVmc _vmc;
		private readonly IVmIdExtractor _extractor;
		private Base? _subCurrentVm;
	}
}