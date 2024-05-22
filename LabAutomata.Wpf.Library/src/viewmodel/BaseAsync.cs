namespace LabAutomata.Wpf.Library.viewmodel;

public abstract class BaseAsync : Base {
    public void Dispose () {
        if (IsDisposed)
            return;

        Cancellation.Cancel();
        Cancellation.Dispose();
        IsDisposed = true;
    }

    protected CancellationTokenSource Cancellation { get; set; } = new();

    protected virtual CancellationToken? CombineToken (CancellationToken? token) {
        ValidateCancellation();

        if (token == null)
            token = Cancellation.Token;
        else {
            ValidateCancellation();
            var source = CancellationTokenSource.CreateLinkedTokenSource(token.Value, Cancellation.Token);
            token = source.Token;
        }

        return token;
    }

    // criteria for returning true and criteria for returning false?
    protected void Reset () => Cancellation.TryReset();

    protected virtual void ValidateCancellation (bool createNew = true) {
        if (Cancellation.IsCancellationRequested) {
            Cancellation.Dispose();

            if (createNew)
                Cancellation = new CancellationTokenSource();
        }
    }

    bool IsDisposed { get; set; }

    protected BaseAsync (IServiceProvider serviceProvider, bool shouldNotifyErrors = false) : base(serviceProvider, shouldNotifyErrors) {
    }

    protected BaseAsync (IServiceProvider sp, IServiceProvider serviceProvider) : base(sp, serviceProvider) {
    }
}