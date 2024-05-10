using LabAutomata.Wpf.Library.src.common;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace LabAutomata {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow (ILogger logger) {
            InitializeComponent();
            _logger = logger;
        }

        private async void RunWork (object sender, RoutedEventArgs e) {
            DbgTxtBlk.Text = "Preparing work...";
            _cancellationTokenSource = new CancellationTokenSource();
            await Task.Delay(2000);

            await Dispatcher.InvokeAsync(async () => {
                var counter = 0;
                using var timer = new PeriodicWork(1);
                var sb = new StringBuilder();

                await timer.WorkAsync(
                    () => OnWorkCallback(sb, ref counter),
                    () => OnExitCondition(ref counter),
                    OnCompleteCallback, _cancellationTokenSource.Token);
            },
                DispatcherPriority.Normal,
                _cancellationTokenSource.Token);
        }

        private void OnCompleteCallback () {
            DbgTxtBlk.Text = "Timer complete!";
            _logger.LogInformation("Period timer is done!");
        }

        private bool OnExitCondition (ref int counter) {
            return counter == 6;
        }

        private void OnWorkCallback (StringBuilder sb, ref int counter) {
            counter++;
            sb.Clear();
            sb.Append("Counter is at ");
            sb.Append(counter);

            DbgTxtBlk.Text = sb.ToString();
        }

        readonly ILogger _logger;
        private CancellationTokenSource _cancellationTokenSource = new();

        private void CancelWork (object sender, RoutedEventArgs e) {
            _cancellationTokenSource.Cancel();
        }
    }
}