using LabAutomata.Wpf.Library.adapter;
using Microsoft.Extensions.Logging;
using System.Windows;
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
				try {
					IsRunning = true;
					await Context.Invoke(parameter);
				}
				catch (Exception e) {
					Logger?.LogError("Exception caught from async command: {error} - {inst}", e.Message, this);
					MessageBox.Show($"{e.Message}");
					throw;
				}
				finally {
					IsRunning = false;
					RaiseCanExecuteChanged();
				}
			}, cancellationToken: _cancellationTokenSource.Token,
				priority: DispatcherPriority.DataBind); // ConfigureAwait(false)?
		}

		private bool IsRunning {
			get => _isRunning;
			set { _isRunning = value; }
		}

		/// <summary>
		/// Creates a new WPF asynchronous command
		/// Requires the Execute method to be awaited, followed by an invocation of RaiseCanExecuteChanged
		/// </summary>
		/// <param name="dA">An adapter with a dispatcher; typically the applicaton's current</param>
		/// <param name="context">Logic to run in the Execute method</param>
		/// <param name="canExecute">Optional delegate logic to determine if this command can execute or now</param>
		/// <param name="msgBox">Optional wrapper for singleton message box</param>
		/// <param name="logger">Optional logger</param>
		public CommandAsync (IAdapter<Dispatcher> dA, Func<object?, Task> context, ILogger? logger = default,
			Func<object?, bool>? canExecute = null) {
			ArgumentNullException.ThrowIfNull(context);
			ArgumentNullException.ThrowIfNull(dA);
			Context = context;
			_canExecute = canExecute;
			_dispatcher = dA.Get();
			_cancellationTokenSource = new CancellationTokenSource();
		}

		/// <summary>
		/// Gets the cancellation token from the internal cancellation token source
		/// </summary>
		protected CancellationToken Token => _cancellationTokenSource.Token;

		/// <summary>
		/// A protected constructor for setting the context from a class deriving from CommandAsync
		/// Calling this constructor assumes you set the Context in the deriving constructor
		/// </summary>
		/// <param name="dA">An adapter with a dispatcher; typically the applicaton's current</param>
		/// <param name="logger">Optional logger</param>
		/// <param name="canExecute">Optional delegate logic to determine if this command can execute or now</param>
		protected CommandAsync (IAdapter<Dispatcher> dA, ILogger? logger = default, Func<object?, bool>? canExecute = default) {
			_dispatcher = dA.Get();
			_canExecute = canExecute;
			Logger = logger;
			_cancellationTokenSource = new CancellationTokenSource();
		}

		protected Func<object?, Task> Context = null!;
		protected readonly ILogger? Logger;
		private readonly Func<object?, bool>? _canExecute;
		private readonly Dispatcher _dispatcher;
		private readonly CancellationTokenSource _cancellationTokenSource;
		private bool _isRunning;
	}
}