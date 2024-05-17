using LabAutomata.Wpf.Library.viewmodel;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace LabAutomata {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow (ILogger logger, MainWindowVm vm) {
            InitializeComponent();
            _logger = logger;
        }

        protected override void OnClosed (EventArgs e) {
            base.OnClosed(e);
            CancelWork();
        }

        public void CancelWork () {
            if (!_cancellationTokenSource.IsCancellationRequested) _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();

        }

        readonly ILogger _logger;
        private readonly MainWindowVm _vm;
        private CancellationTokenSource _cancellationTokenSource = new();
    }
}