using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.common;
using Microsoft.Extensions.Logging;
using System.Windows.Threading;

namespace LabAutomata.Wpf.Library.commands {
	/// <summary>
	/// Represents an abstract base class for creating a database model command.
	/// </summary>
	public abstract class ToDatabaseModelCommand<TDomainService> : CommandAsync {
		/// <summary>
		/// Creates a new database model based on the provided object.
		/// </summary>
		/// <param name="obj">The object to create the database model from.</param>
		public abstract Task Create (object? obj);

		protected Action? Callback { get; set; }

		protected TDomainService Service { get; }

		protected ILogger? Logger { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ToDatabaseModelCommand{TDomainService}"/> class.
		/// </summary>
		/// <param name="dA">The adapter for the dispatcher.</param>
		/// <param name="service">The repository for the database model.</param>
		/// <param name="callback">Optional callback for when the command completes</param>
		/// <param name="logger">Optional logger</param>
		/// <param name="canExecute">The optional function to determine if the command can be executed.</param>
		protected ToDatabaseModelCommand (
			IAdapter<Dispatcher> dA,
			TDomainService service,
			Action? callback = default,
			ILogger? logger = default,
			Func<object?, bool>? canExecute = null) : base(dA, logger, canExecute) {
			ArgumentNullException.ThrowIfNull(service, "Repository cannot be null - {repo}");
			Service = service;
			Callback = callback;
			Context = Create;
			Logger = logger;
		}
	}
}