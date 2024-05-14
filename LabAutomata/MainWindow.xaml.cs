using LabAutomata.Library.common;
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

            CancelWork();

            _cancellationTokenSource = new CancellationTokenSource();
            using var timer = new PeriodicWork(1);
            _cancellationTokenSource.Token.Register(() => timer.Dispose());

            var delayTask = Task.Delay(2000, _cancellationTokenSource.Token);
            var continueTask = delayTask.ContinueWith(t => { });
            await continueTask;

            await Dispatcher.InvokeAsync(async () => {
                var counter = 0;
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

        protected override void OnClosed (EventArgs e) {
            base.OnClosed(e);
            CancelWork();
        }

        void CancelWork () {
            if (!_cancellationTokenSource.IsCancellationRequested) _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }

        readonly ILogger _logger;
        private CancellationTokenSource _cancellationTokenSource = new();
    }
}