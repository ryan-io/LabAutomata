using System.Windows;
using System.Windows.Controls;

namespace LabAutomata.controls {
    /// <summary>
    /// Interaction logic for FormTextInput.xaml
    /// </summary>
    public partial class FormTextInput : UserControl {
        public string InputTxt {
            get => (string)GetValue(InputTxtProperty);
            set => SetValue(InputTxtProperty, value);
        }

        public static readonly DependencyProperty InputTxtProperty =
            DependencyProperty.Register(nameof(InputTxt),
                typeof(string),
                typeof(FormTextInput),
                new FrameworkPropertyMetadata(string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public FormTextInput () {
            InitializeComponent();
        }
    }
}
