using System.Windows;
using System.Windows.Controls;

namespace LabAutomata.view {
    /// <summary>
    /// Interaction logic for Footer.xaml
    /// </summary>
    public partial class Footer : UserControl {
        public string FooterText {
            get => (string)GetValue(FooterTextProperty);
            set => SetValue(FooterTextProperty, value);
        }

        public static readonly DependencyProperty FooterTextProperty =
            DependencyProperty.Register(nameof(FooterText),
            typeof(string),
            typeof(Footer),
            new PropertyMetadata(string.Empty));

        public Footer () {
            InitializeComponent();
        }
    }
}
