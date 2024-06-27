using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Wpf.Library.domain_models;
using System.Collections.ObjectModel;

namespace LabAutomata.Wpf.Library.mediator_stores {
	/// <summary>
	/// this store should be registered as a Singleton in order to persist state for workstations
	/// throughout the lifetime of the application
	/// this is the source of truth for Workstations
	/// implements IDisposable; if this class is used in a transient manner, Dispose should be invoked
	/// </summary>
	public class WorkstationStore : IDisposable {
		public event Action<WorkstationDomainModel>? StateChanged;

		public IEnumerable<WorkstationDomainModel> Workstations => _workstations;

		public void AddWorkstation (WorkstationDomainModel model) {
			StateChanged?.Invoke(model);
		}

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
			var workstations = await _repository.GetAll(token);
			List<WorkstationDomainModel> models = new();

			foreach (var ws in workstations) {
				var wsdm = new WorkstationDomainModel(ws);
				models.Add(wsdm);
			}

			_workstations = new ObservableCollection<WorkstationDomainModel>(models);
		}

		public WorkstationStore (IRepository<Workstation> repository) {
			_repository = repository;
		}

		private bool IsDisposed { get; set; }

		private ObservableCollection<WorkstationDomainModel> _workstations = new();

		readonly IRepository<Workstation> _repository;
	}
}
