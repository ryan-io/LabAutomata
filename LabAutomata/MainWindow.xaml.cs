using LabAutomata.Wpf.Library.data_structures;
using LabAutomata.Wpf.Library.viewmodel;
using Microsoft.Extensions.Logging;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace LabAutomata {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow (MainWindowVm vm, ILogger? logger = default) {
            InitializeComponent();
            _vm = vm;
            _logger = logger;
            DataContext = _vm;
        }

        // no reason to move this logic into a view model... 
        // DragMove() is strictly a Window action (UI only)
        private void UIElement_OnMouseLeftButtonDown (object sender, MouseButtonEventArgs e) {
            DragMove();
        }

        private async void OnLoaded (object sender, RoutedEventArgs e) {
            try {
                ApplicationThemeManager.Apply(ApplicationTheme.Dark, WindowBackdropType.Auto);

                _logger?.LogInformation("Application has been loaded.");
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

        private readonly MainWindowVm _vm;
        private readonly CancellationTokenSource _cancellation = new();
        private readonly ILogger? _logger;


    }
}