﻿using Microsoft.Extensions.Logging;

namespace LabAutomata.Wpf.Library.viewmodel;

public abstract class BaseAsync : Base {
    public void Dispose () {
        if (IsDisposed)
            return;

        Cancellation.Cancel();
        Cancellation.Dispose();
        IsDisposed = true;
    }

    public CancellationTokenSource Cancellation { get; set; } = new();

    public virtual CancellationToken? CombineToken (CancellationToken? token) {
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

    protected BaseAsync (ILogger? logger = default, bool shouldNotifyErrors = false) : base(logger, shouldNotifyErrors) {
    }
}