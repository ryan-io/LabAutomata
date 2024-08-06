using LabAutomata.DataAccess.service;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.domain_models;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace LabAutomata.Wpf.Library.mediator_stores {
	#region ABSTRACTION
	public interface IWorkstationStore {
		event Action<WorkstationDomainModel>? StateChanged;
		IEnumerable<WorkstationDomainModel> Workstations { get; }
		Task Load (CancellationToken token = default);
		void AddWorkstation (WorkstationDomainModel model);
		void RemoveWorkstation (WorkstationDomainModel model);
	}
	#endregion

	/// <summary>
	/// this store should be registered as a Singleton in order to persist state for workstations
	/// throughout the lifetime of the application
	/// this is the source of truth for Workstations
	/// implements IDisposable; if this class is used in a transient manner, Dispose should be invoked
	/// </summary>
	public sealed class WorkstationStore : IWorkstationStore {
		public event Action<WorkstationDomainModel>? StateChanged;

		public IEnumerable<WorkstationDomainModel> Workstations => _workstations;

		public void AddWorkstation (WorkstationDomainModel model) {
			if (_workstations.Contains(model)) return;

			_workstations.Add(model);
			StateChanged?.Invoke(model);
		}

		public void RemoveWorkstation (WorkstationDomainModel model) {
			if (!_workstations.Contains(model))
				return;

			_workstations.Remove(model);
			StateChanged?.Invoke(model);
		}

		/// <summary>
		/// This class SHOULD NOT define a destructor
		/// It should also not have dispose manually invoked, unless this is registered
		/// as a transient in dependency injection
		/// </summary>
		public void Dispose () {
			if (IsDisposed) return;

			if (StateChanged != null)
				foreach (var subscriber in StateChanged.GetInvocationList()) {
					var action = (Action<WorkstationDomainModel>)subscriber;
					StateChanged -= action;
				}

			IsDisposed = true;
		}

		public async Task Load (CancellationToken token = default) {
			var workstations = await _service.GetWorkstations(token);

			if (workstations.IsError) {
				_logger?.LogError(workstations.Errors.First().Description);
				return;
			}


			List<WorkstationDomainModel> models = new();

			foreach (var ws in workstations.Value) {
				var wsdm = ws.ToDomain();
				models.Add(wsdm);
			}

			_workstations = new ObservableCollection<WorkstationDomainModel>(models);
		}

		public WorkstationStore (IWorkstationService service, ILogger? logger = default) {
			_service = service;
			_logger = logger;
		}

		private bool IsDisposed { get; set; }

		private ObservableCollection<WorkstationDomainModel> _workstations = new();

		readonly IWorkstationService _service;
		readonly ILogger? _logger;
	}
}
