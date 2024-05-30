using System.Windows;
using System.Windows.Controls;

namespace LabAutomata.controls {
    public partial class DataGridHeader : UserControl {
        public string Text {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text),
                typeof(string),
                typeof(DataGridHeader),
                new PropertyMetadata(string.Empty));

        public DataGridHeader () {
            InitializeComponent();
        }
    }
}
