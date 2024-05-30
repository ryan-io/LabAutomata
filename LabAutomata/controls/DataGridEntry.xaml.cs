using System.Windows;
using System.Windows.Controls;

namespace LabAutomata.controls {
    public partial class DataGridEntry : UserControl {
        public string EntryText {
            get => (string)GetValue(EntryTextProperty);
            set => SetValue(EntryTextProperty, value);
        }

        public static readonly DependencyProperty EntryTextProperty =
            DependencyProperty.Register(nameof(EntryText),
                typeof(string),
                typeof(DataGridEntry),
                new PropertyMetadata(string.Empty));

        public DataGridEntry () {
            InitializeComponent();
        }
    }
}
