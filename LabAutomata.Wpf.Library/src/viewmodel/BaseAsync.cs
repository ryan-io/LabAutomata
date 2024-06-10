using Microsoft.Extensions.Logging;

namespace LabAutomata.Wpf.Library.viewmodel;

/// <summary>
/// Represents a base class for asynchronous operations in the view model.
/// This class handles its own creation of a CancellationTokenSource
/// You should invoke CombineToken to tie in your own token with the internal token of this class
/// </summary>
public abstract class BaseAsync : Base {

	/// <summary>
	/// Gets or sets the cancellation token source for the asynchronous operation.
	/// </summary>
	public CancellationTokenSource Cancellation { get; set; } = new();

	/// <summary>
	/// Combines the provided cancellation token with the internal cancellation token.
	/// </summary>
	/// <param name="token">The cancellation token to combine.</param>
	/// <returns>The combined cancellation token.</returns>
	public virtual CancellationToken? CombineToken (CancellationToken? token) {
		ValidateCancellation();

		if (token == null) {
			token = Cancellation.Token;
		}
		else {
			ValidateCancellation();
			var source = CancellationTokenSource.CreateLinkedTokenSource(token.Value, Cancellation.Token);
			token = source.Token;
		}

		return token;
	}

	/// <summary>
	/// Resets the cancellation token to its initial state.
	/// </summary>
	protected void Reset () => Cancellation.TryReset();

	/// <summary>
	/// Validates the cancellation token and creates a new one if necessary.
	/// </summary>
	/// <param name="createNew">Specifies whether to create a new cancellation token if the current one is already cancelled.</param>
	protected virtual void ValidateCancellation (bool createNew = true) {
		if (Cancellation.IsCancellationRequested) {
			Cancellation.Dispose();

			if (createNew) {
				Cancellation = new CancellationTokenSource();
			}
		}
	}

	/// <summary>
	/// Disposes the resources used by the <see cref="BaseAsync"/> class.
	/// </summary>
	public void Dispose () {
		if (IsDisposed) {
			return;
		}

		Cancellation.Cancel();
		Cancellation.Dispose();
		IsDisposed = true;
	}

	/// <summary>
	/// Gets or sets a value indicating whether the <see cref="BaseAsync"/> class has been disposed.
	/// </summary>
	private bool IsDisposed { get; set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="BaseAsync"/> class.
	/// </summary>
	/// <param name="logger">The logger to use for logging.</param>
	/// <param name="shouldNotifyErrors">Specifies whether to notify errors.</param>
	protected BaseAsync (ILogger? logger = default, bool shouldNotifyErrors = false) : base(logger, shouldNotifyErrors) {
	}
}