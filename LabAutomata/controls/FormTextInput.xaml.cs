using System.Windows;
using System.Windows.Controls;

namespace LabAutomata.controls {
    /// <summary>
    /// Interaction logic for FormTextInput.xaml
    /// </summary>
    public partial class FormTextInput : UserControl {
        public string Input {
            get => (string)GetValue(InputProperty);
            set => SetValue(InputProperty, value);
        }

        public static readonly DependencyProperty InputProperty =
            DependencyProperty.Register(nameof(Input),
                typeof(string),
                typeof(FormLabel),
                new PropertyMetadata(string.Empty));

        public int MaximumLines {
            get => (int)GetValue(MaximumLinesProperty);
            set => SetValue(MaximumLinesProperty, value);
        }

        public static readonly DependencyProperty MaximumLinesProperty =
            DependencyProperty.Register(nameof(MaximumLines),
                typeof(int),
                typeof(FormLabel),
                new PropertyMetadata(5));

        public int MinimumLines {
            get => (int)GetValue(MinimumLinesProperty);
            set => SetValue(MinimumLinesProperty, value);
        }

        public static readonly DependencyProperty MinimumLinesProperty =
            DependencyProperty.Register(nameof(MinimumLines),
                typeof(int),
                typeof(FormLabel),
                new PropertyMetadata(0));

        public FormTextInput () {
            InitializeComponent();
        }
    }
}
