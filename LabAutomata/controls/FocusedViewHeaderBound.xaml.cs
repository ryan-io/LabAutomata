using LabAutomata.Wpf.Library.viewmodel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace LabAutomata.controls {
	/// <summary>
	/// Interaction logic for FocusedViewHeaderBound.xaml
	/// </summary>
	public partial class FocusedViewHeaderBound : UserControl {
		public ObservableCollection<PlotViewModel> Plots {
			get => (ObservableCollection<PlotViewModel>)GetValue(PlotsProperty);
			set => SetValue(PlotsProperty, value);
		}

		public static readonly DependencyProperty PlotsProperty =
			DependencyProperty.Register(nameof(Plots),
				typeof(ObservableCollection<PlotViewModel>),
				typeof(FocusedViewHeaderBound),
				new PropertyMetadata());

		public PlotViewModel SelectedPlot {
			get => (PlotViewModel)GetValue(SelectedPlotProperty);
			set {
				SetValue(SelectedPlotProperty, value);
			}
		}

		public static readonly DependencyProperty SelectedPlotProperty =
			DependencyProperty.Register(nameof(SelectedPlot),
				typeof(PlotViewModel),
				typeof(FocusedViewHeaderBound),
				new PropertyMetadata());


		public string HeaderTextBound {
			get => (string)GetValue(HeaderTextBoundProperty);
			set => SetValue(HeaderTextBoundProperty, value);
		}

		public static readonly DependencyProperty HeaderTextBoundProperty =
			DependencyProperty.Register(nameof(HeaderTextBound),
				typeof(string),
				typeof(FocusedViewHeaderBound),
				new PropertyMetadata("This is for demo purposes"));

		public FocusedViewHeaderBound () {
			InitializeComponent();
		}
	}
}
