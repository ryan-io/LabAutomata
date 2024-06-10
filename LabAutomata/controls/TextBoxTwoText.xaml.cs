using System.Windows;
using System.Windows.Controls;

namespace LabAutomata.controls {

	/// <summary>
	/// Interaction logic for TextBoxTwoText.xaml
	/// </summary>
	public partial class TextBoxTwoText : TextBox {

		public string BoxEmptyText {
			get => (string)GetValue(BoxEmptyTextProperty);
			set => SetValue(BoxEmptyTextProperty, value);
		}

		public static readonly DependencyProperty BoxEmptyTextProperty =
			DependencyProperty.Register(nameof(BoxEmptyText),
				typeof(string),
				typeof(TextBoxTwoText),
				new FrameworkPropertyMetadata(string.Empty,
					FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		public TextBoxTwoText () {
			InitializeComponent();
		}
	}
}