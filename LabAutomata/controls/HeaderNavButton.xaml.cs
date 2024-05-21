using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LabAutomata.controls {
    /// <summary>
    /// Interaction logic for HeaderNavButton.xaml
    /// </summary>
    public partial class HeaderNavButton : UserControl {
        public ICommand Click {
            get => (ICommand)GetValue(ClickProperty);
            set => SetValue(ClickProperty, value);
        }

        public static readonly DependencyProperty ClickProperty =
            DependencyProperty.Register(nameof(Click),
                typeof(ICommand),
                typeof(HeaderNavButton),
                new PropertyMetadata(default));

        public string ClickParameter {
            get => (string)GetValue(ClickParameterProperty);
            set => SetValue(ClickParameterProperty, value);
        }

        public static readonly DependencyProperty ClickParameterProperty =
            DependencyProperty.Register(nameof(ClickParameter),
                typeof(string),
                typeof(HeaderNavButton),
                new PropertyMetadata(string.Empty));

        public string ButtonId {
            get => (string)GetValue(ButtonIdProperty);
            set => SetValue(ButtonIdProperty, value);
        }

        public static readonly DependencyProperty ButtonIdProperty =
            DependencyProperty.Register(nameof(ButtonId),
                typeof(string),
                typeof(HeaderNavButton),
                new PropertyMetadata(string.Empty));

        public ImageSource Source {
            get => (ImageSource)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register(nameof(Source),
                typeof(ImageSource),
                typeof(HeaderNavButton),
                new PropertyMetadata(default));

        public HeaderNavButton () {
            InitializeComponent();
        }
    }
}
