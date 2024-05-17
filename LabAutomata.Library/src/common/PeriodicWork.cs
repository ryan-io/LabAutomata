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
    /// <param name="period">Time interval to tick</param>
    public class PeriodicWork (int period = 1) : IDisposable {
        public async Task WorkAsync (Action? callback, Func<bool> exitCondition, Action? completeCallback = null, CancellationToken token = default) {
            if (_isDisposed || _isRunning) return;

            _isRunning = true;
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

            while (!exitCondition.Invoke()) {
                await timer.WaitForNextTickAsync(token);
                callback?.Invoke();
            }
            _timer.Dispose();
            completeCallback?.Invoke();
            _isRunning = false;
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

            period = newPeriod;
        }

        private bool _isDisposed;
        private bool _isRunning;
        private readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(period));
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