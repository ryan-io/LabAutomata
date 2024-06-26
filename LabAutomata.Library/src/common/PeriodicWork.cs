namespace LabAutomata.Library.common {

	/// <summary>
	/// Handles an asynchronous unit of work
	/// Use this class along with Dispatcher.InvokeAsync to prevent UI thread blocking
	/// Invokes callBack after every tick
	/// Checks exitCondition on when to exit the loop
	/// Invokes completeCallback when exitCondition is true
	/// invoke WorkAsync with 'using'
	///     WorkAsync does invoke Dispose() on successful work completed
	/// </summary>
	public class PeriodicWork : IDisposable {

		public async Task WorkAsync (Func<bool> exitCondition, Action? completeCallback = null, CancellationToken token = default) {
			if (_isDisposed || _isRunning) return;

			ArgumentNullException.ThrowIfNull(exitCondition, "Exit condition cannot be null for periodic work.");

			_isRunning = true;
			var timer = new PeriodicTimer(TimeSpan.FromSeconds(_period));

			try {
				while (!exitCondition.Invoke()) {
					await timer.WaitForNextTickAsync(token);
					await _callback.Invoke();
				}
			}
			catch (Exception) {
				_timer.Dispose();
				_isRunning = false;
			}
			completeCallback?.Invoke();
		}

		public void Dispose () {
			if (_isDisposed)
				return;

			_timer.Dispose();
			_isDisposed = true;
		}

		/// <summary>
		/// Modifies the period to a new value.
		/// Care should be taken when change the period. If the work has begun, this method will have no effect
		/// </summary>
		/// <param name="newPeriod">New period value</param>
		/// <exception cref="ArgumentOutOfRangeException">Thrown if newPeriod is less than or equal to '0'</exception>
		public void SetPeriod (int newPeriod) {
			if (newPeriod <= 0)
				throw new ArgumentOutOfRangeException(nameof(newPeriod));

			_period = newPeriod;
		}

		private bool _isDisposed;
		private bool _isRunning;
		private readonly PeriodicTimer _timer;
		private int _period;

		/// <summary>
		/// Handles an asynchronous unit of work
		/// Use this class along with Dispatcher.InvokeAsync to prevent UI thread blocking
		/// Invokes callBack after every tick
		/// Checks exitCondition on when to exit the loop
		/// Invokes completeCallback when exitCondition is true
		/// invoke WorkAsync with 'using'
		///     WorkAsync does invoke Dispose() on successful work completed
		/// </summary>
		/// <param name="callback">Callback to invoke after period</param>
		/// <param name="period">Time interval to tick in seconds</param>
		public PeriodicWork (Func<Task> callback, int period = 1) {
			_callback = callback;
			_period = period;
			_timer = new(TimeSpan.FromSeconds(period));
		}

		private readonly Func<Task> _callback;
	}
}

/* example
 *  private async void RunWork (object sender, RoutedEventArgs e) {
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
 */