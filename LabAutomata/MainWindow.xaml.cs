using LabAutomata.Db.common;
using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.data_structures;
using LabAutomata.Wpf.Library.viewmodel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace LabAutomata {
    public class ApplicationEntryCommand : CommandAsync {

        public ApplicationEntryCommand (IServiceProvider sp, IAdapter<Dispatcher> adapter) : base(adapter) {

        }


    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow (MainWindowVm vm, IServiceProvider sp, IVmc vmc, ILogger? logger = default) {
            InitializeComponent();
            _vm = vm;
            _logger = logger;
            DataContext = _vm;
            _vmc = vmc;
            _sp = sp;
        }

        // no reason to move this logic into a view model... 
        // DragMove() is strictly a Window action (UI only)
        private void UIElement_OnMouseLeftButtonDown (object sender, MouseButtonEventArgs e) {
            DragMove();
        }

        private async void OnLoaded (object sender, RoutedEventArgs e) {
            var dbCtxs = new List<ILabPostgreSqlDbContext>();
            try {
                ApplicationThemeManager.Apply(ApplicationTheme.Dark, WindowBackdropType.Auto);

                _logger?.LogInformation("Application has been loaded.");

                var v = _vmc.GetValues().ToArray();
                var count = v.Length;

                for (int i = 0; i < count; i++) {
                    dbCtxs.Add(_sp.GetRequiredService<ILabPostgreSqlDbContext>());
                }

                var tasks = new List<Task>();

                foreach (var vm in v) {
                    //await vm.LoadAsync(_cancellation.Token);
                    tasks.Add(vm.LoadAsync(_cancellation.Token));
                    vm.Load();
                }

                //await Task.WhenAll(tasks);
            }
            catch (Exception exception) {
                _vm.Logger?.LogError(exception.Message);
                await _cancellation.CancelAsync();
                throw;
            }
            finally {
                foreach (var c in dbCtxs) {
                    await c.PostgreSqlDb.DisposeAsync();
                }

                _logger?.LogInformation("Disposing database contexts");
            }
        }

        private readonly MainWindowVm _vm;
        private readonly CancellationTokenSource _cancellation = new();
        private readonly IServiceProvider _sp;
        private readonly ILogger? _logger;
        private readonly IVmc _vmc;


    }
}