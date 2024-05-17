using LabAutomata.Wpf.Library.adapter;
using System.Windows.Input;
using System.Windows.Threading;

namespace LabAutomata.Wpf.Library.common {
    public class CommandAsync : ICommand {
        /// <summary>
        ///  Wrapper for application commands
        ///  CanExecute is dependent on a Func<object?, bool>, specified in ctor
        ///  Execute is dependent on a Action<object?>, specified in ctor
        /// </summary>
        /// <summary>
        ///  Ties into the CommandManager to verify if this command implementation can be raised
        /// </summary>
        public event EventHandler? CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void RaiseCanExecuteChanged () => CommandManager.InvalidateRequerySuggested();

        // invokes the Cancel() of the CancellationTokenSource
        public void Cancel () {
            _cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// Checks if _canExecute is null -> returns false
        /// Used generically to check if this instance can actually invoke its context
        /// </summary>
        /// <param name="parameter">object to pass to _canExecute</param>
        /// <returns>False if _canExecute is null, else result from _canExecute</returns>
        public bool CanExecute (object? parameter) {
            if (_canExecute == null) {
                return !IsRunning;
            }

            return !IsRunning && _canExecute.Invoke(parameter);
        }

        /// <summary>
        ///  Invokes the context action asynchronously. Should be wrapped in try-get
        /// </summary>
        /// <param name="parameter">object to pass to action _context</param>
        public async void Execute (object? parameter) {
            IsRunning = true;
            RaiseCanExecuteChanged();

            await _dispatcher.InvokeAsync(() => _context.Invoke(parameter),
                    cancellationToken: _cancellationTokenSource.Token,
                    priority: DispatcherPriority.Normal)
                     .Task.ContinueWith(_ => {
                         RaiseCanExecuteChanged();
                         IsRunning = false;
                     }, cancellationToken: _cancellationTokenSource.Token); // ConfigureAwait(false)?
        }

        private bool IsRunning { get; set; }

        public CommandAsync (IAdapter<Dispatcher> da, Func<object?, Task> context, Func<object?, bool>? canExecute = null) {
            ArgumentNullException.ThrowIfNull(context);
            _context = context;
            _canExecute = canExecute;
            _dispatcher = da.Get();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private readonly Func<object?, Task> _context;
        private readonly Func<object?, bool>? _canExecute;
        private readonly Dispatcher _dispatcher;
        private readonly CancellationTokenSource _cancellationTokenSource;
    }
}