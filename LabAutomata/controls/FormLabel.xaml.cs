using System.Windows;
using System.Windows.Controls;

namespace LabAutomata.controls {

	public partial class FormLabel : UserControl {

		public string Label {
			get => (string)GetValue(LabelProperty);
			set => SetValue(LabelProperty, value);
		}

		public static readonly DependencyProperty LabelProperty =
			DependencyProperty.Register(nameof(Label),
				typeof(string),
				typeof(FormLabel),
				new PropertyMetadata(string.Empty));

		public FormLabel () {
			InitializeComponent();
		}
	}
}