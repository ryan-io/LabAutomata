namespace LabAutomata.Wpf.Library.src.common {
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
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

            while (!exitCondition.Invoke()) {
                await timer.WaitForNextTickAsync(token);
                callback?.Invoke();
            }
            completeCallback?.Invoke();
            Dispose();
        }

        public void Dispose () {
            if (_isDisposed)
                return;

            _timer.Dispose();
            _isDisposed = true;
        }

        private bool _isDisposed;
        private readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(period));
    }
}