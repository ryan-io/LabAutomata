using LabAutomata.Wpf.Library.viewmodel;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace LabAutomata {

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {

		public MainWindow (WindowNavigator navigator) {
			DataContext = navigator;
			InitializeComponent();

			ApplicationThemeManager.Apply(ApplicationTheme.Dark, WindowBackdropType.Auto);
		}

		// no reason to move this logic into a view model...
		// DragMove() is strictly a Window action (UI only)
		private void UIElement_OnMouseLeftButtonDown (object sender, MouseButtonEventArgs e) {
			DragMove();
		}
	}
}