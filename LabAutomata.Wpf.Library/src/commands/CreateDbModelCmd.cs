using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.domain_models;
using Microsoft.Extensions.Logging;
using System.Windows.Threading;

namespace LabAutomata.Wpf.Library.commands {

	/// <summary>
	/// Represents an abstract base class for creating a database model command.
	/// </summary>
	/// <typeparam name="TDomain">The domain model type.</typeparam>
	/// <typeparam name="TModel">The database model type.</typeparam>
	public abstract class CreateDbModelCmd<TDomain, TModel> : CommandAsync
		where TDomain : DomainModel<TModel>
		where TModel : LabModel {
		private readonly IRepository<TModel> _repository;
		private readonly Action? _callback;

		/// <summary>
		/// Initializes a new instance of the <see cref="CreateDbModelCmd{TDomain, TModel}"/> class.
		/// </summary>
		/// <param name="dA">The adapter for the dispatcher.</param>
		/// <param name="repository">The repository for the database model.</param>
		/// <param name="callback">Optional callback for when the command completes</param>
		/// <param name="logger">Optional logger</param>
		/// <param name="canExecute">The optional function to determine if the command can be executed.</param>
		protected CreateDbModelCmd (IAdapter<Dispatcher> dA, IRepository<TModel> repository, Action? callback = default, ILogger? logger = default, Func<object?, bool>? canExecute = null)
			: base(dA, logger, canExecute) {
			ArgumentNullException.ThrowIfNull(repository, "Repository cannot be null - {repo}");
			_repository = repository;
			_callback = callback;
			Context = Create;
		}

		/// <summary>
		/// Creates a new database model based on the provided object.
		/// </summary>
		/// <param name="obj">The object to create the database model from.</param>
		public async Task Create (object? obj) {
			if (obj is not TDomain dM) return;

			try {
				await _repository.Create(dM.ToDbModel());
				_callback?.Invoke();
				Logger?.LogInformation("Creating DbModel status: - {dM}", dM);
			}
			catch (Exception e) {
				Logger?.LogError("An error occurred: {name} - {msg}", nameof(Create), e.InnerException);
				throw;
			}
		}
	}
}