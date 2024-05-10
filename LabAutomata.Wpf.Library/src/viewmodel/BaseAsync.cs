namespace LabAutomata.Wpf.Library.viewmodel;

public class BaseAsync : Base {
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
}