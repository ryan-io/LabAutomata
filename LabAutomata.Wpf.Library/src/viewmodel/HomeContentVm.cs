using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace LabAutomata.Wpf.Library.viewmodel;

public interface ISelectedPlotObservable {
	void RegisterOnSelectedPlotChange (PropertyChangedEventHandler handler);
	void UnegisterOnSelectedPlotChange (PropertyChangedEventHandler handler);
}

public class HomeContentVm : Base, ISelectedPlotObservable {
	public void RegisterOnSelectedPlotChange (PropertyChangedEventHandler handler) {
		PropertyChanged += handler;
	}

	public void UnegisterOnSelectedPlotChange (PropertyChangedEventHandler handler) {
		PropertyChanged -= handler;
	}

	public ObservableCollection<PlotViewModel> Plots { get; } = new();

	public PlotViewModel? SelectedPlot {
		get => _selectedPlot;
		private set {
			_selectedPlot = value;
			NotifyPropertyChanged();
		}
	}

	private PlotViewModel? _selectedPlot = default;

	public HomeContentVm (PlotViewModel plotViewModel, ILogger? logger = default) : base(logger, true) {
		Plots.Add(plotViewModel);
		_selectedPlot = plotViewModel;
		RegisterOnSelectedPlotChange(plotViewModel.HandleSelectedPlotChange);
	}
}