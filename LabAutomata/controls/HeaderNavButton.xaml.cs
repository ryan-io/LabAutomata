using System.Windows;
using System.Windows.Controls;

namespace LabAutomata.controls {
    /// <summary>
    /// Interaction logic for HeaderNavButton.xaml
    /// </summary>
    public partial class HeaderNavButton : UserControl {
        public string ButtonId {
            get => (string)GetValue(ButtonIdProperty);
            set => SetValue(ButtonIdProperty, value);
        }

        public static readonly DependencyProperty ButtonIdProperty =
            DependencyProperty.Register(nameof(ButtonId),
                typeof(string),
                typeof(HeaderNavButton),
                new PropertyMetadata("Button"));

        public string Source {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register(nameof(Source),
                typeof(string),
                typeof(HeaderNavButton),
                new PropertyMetadata("Button"));

        public HeaderNavButton () {
            InitializeComponent();
        }
    }
}
