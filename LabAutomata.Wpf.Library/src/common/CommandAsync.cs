using Microsoft.Extensions.Logging;
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
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        ///  This method should be invoked every time a dependency property is changed in a viewmodel
        ///  This method is key resetting the state of uielements that depends on using the CanExecute method
        ///  to check whether this command can be invoked again or not
        /// </summary>
        public void RaiseCanExecuteChanged () {
            CommandManager.InvalidateRequerySuggested();
        }

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
        public bool CanExecute (object? parameter = null) {
            if (_canExecute == null) {
                return !IsRunning;
            }

            return IsRunning && _canExecute.Invoke(parameter);
        }

        /// <summary>
        ///  Invokes the context action asynchronously. Should be wrapped in try-get
        /// </summary>
        /// <param name="parameter">object to pass to action _context</param>
        public async void Execute (object? parameter) {
            await _dispatcher.InvokeAsync(async () => {
                IsRunning = true;
                _logger.LogInformation("Starting async command");
                await _context.Invoke(parameter);
                IsRunning = false;
                _logger.LogInformation("Ending async command");

                CanExecute();
            }, cancellationToken: _cancellationTokenSource.Token,
                priority: DispatcherPriority.DataBind); // ConfigureAwait(false)?
        }

        private bool IsRunning {
            get => _isRunning;
            set {
                _isRunning = value;
            }
        }

        public CommandAsync (Dispatcher dispatcher, ILogger logger, Func<object?, Task> context, Func<object?, bool>? canExecute = null) {
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(dispatcher);
            _logger = logger;
            _context = context;
            _canExecute = canExecute;
            _dispatcher = dispatcher;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        readonly ILogger _logger;
        private readonly Func<object?, Task> _context;
        private readonly Func<object?, bool>? _canExecute;
        private readonly Dispatcher _dispatcher;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private bool _isRunning;
    }
}