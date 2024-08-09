using Microsoft.Extensions.Logging;

namespace LabAutomata.Wpf.Library.viewmodel;

public class HomeContentVm : Base {
	private PlotViewModel _plotViewModel = null!;

	public PlotViewModel PlotViewModel {
		get => _plotViewModel;
		set {
			_plotViewModel = value;
			NotifyPropertyChanged();
		}
	}

	public HomeContentVm (PlotViewModel plotViewModel, ILogger? logger = default) : base(logger, true) {
		PlotViewModel = plotViewModel;
	}
}