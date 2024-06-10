using System.Windows;
using System.Windows.Controls;

namespace LabAutomata.controls {

	/// <summary>
	/// Interaction logic for ContentCard.xaml
	/// </summary>
	public partial class ContentCard : UserControl {

		public object CardContent {
			get => GetValue(CardContentProperty);
			set => SetValue(CardContentProperty, value);
		}

		// Using a DependencyProperty as the backing store for CardContent.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CardContentProperty =
			DependencyProperty.Register(nameof(CardContent),
				typeof(object),
				typeof(ContentCard),
				new PropertyMetadata(default));

		public ContentCard () {
			InitializeComponent();
		}
	}
}