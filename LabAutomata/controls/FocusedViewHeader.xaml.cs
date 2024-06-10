using System.Windows;
using System.Windows.Controls;

namespace LabAutomata.controls {

	public partial class FocusedViewHeader : UserControl {

		public string HeaderText {
			get => (string)GetValue(HeaderTextProperty);
			set => SetValue(HeaderTextProperty, value);
		}

		public static readonly DependencyProperty HeaderTextProperty =
			DependencyProperty.Register(nameof(HeaderText),
				typeof(string),
				typeof(FocusedViewHeader),
				new PropertyMetadata("This is for demo purposes"));

		public FocusedViewHeader () {
			InitializeComponent();
		}
	}
}