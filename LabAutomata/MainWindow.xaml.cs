using LabAutomata.Wpf.Library.viewmodel;
using Microsoft.Extensions.Logging;
using System.Windows;
using System.Windows.Input;

namespace LabAutomata {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow (MainWindowVm vm) {
            InitializeComponent();
            _vm = vm;
            DataContext = _vm;
        }

        private readonly MainWindowVm _vm;

        // no reason to move this logic into a view model... 
        // DragMove() is strictly a Window action (UI only)
        private void UIElement_OnMouseLeftButtonDown (object sender, MouseButtonEventArgs e) {
            DragMove();
            _vm.Logger?.LogInformation("Testing log from mainwindow");
        }
    }
}