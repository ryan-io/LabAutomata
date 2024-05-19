using LabAutomata.Wpf.Library.data_structures;
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

        // no reason to move this logic into a view model... 
        // DragMove() is strictly a Window action (UI only)
        private void UIElement_OnMouseLeftButtonDown (object sender, MouseButtonEventArgs e) {
            DragMove();
        }

        private async void OnLoaded (object sender, RoutedEventArgs e) {
            try {
                HashSet<Task> tasks = new HashSet<Task>();

                foreach (var vm in Vmc.Instance.Values) {
                    vm.Load();
                    tasks.Add(vm.LoadAsync(_cancellation.Token));
                }

                await Task.WhenAll(tasks);
            }
            catch (Exception exception) {
                _vm.Logger?.LogError(exception.Message);
                await _cancellation.CancelAsync();
                throw;
            }
        }

        protected override void OnClosed (EventArgs e) {
            base.OnClosed(e);
            _cancellation.Cancel();
        }

        private readonly MainWindowVm _vm;
        private readonly CancellationTokenSource _cancellation = new();
    }
}