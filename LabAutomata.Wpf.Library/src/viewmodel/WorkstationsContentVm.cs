using LabAutomata.Wpf.Library.domain_models;
using LabAutomata.Wpf.Library.mediator_stores;
using Microsoft.Extensions.Logging;

namespace LabAutomata.Wpf.Library.viewmodel;

/// <summary>
/// Represents the view model for the WorkstationsContent view.
/// </summary>
public class WorkstationsContentVm : Base {
	/// <summary>
	/// Gets or sets the collection of workstations.
	/// </summary>
	public IEnumerable<WorkstationDomain> Workstations => _workstationStore.Workstations;

	//TODO: implement this method properly
	public override Task LoadAsync (CancellationToken token = default) {
		//var workstations = await _repository.GetAll(token);
		//List<WorkstationDomainModel> models = new();

		//foreach (var ws in workstations) {
		//	var wsdm = new WorkstationDomainModel(ws);
		//	models.Add(wsdm);
		//}

		//_workstations = new ObservableCollection<WorkstationDomainModel>(models);
		return Task.CompletedTask;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="WorkstationsContentVm"/> class.
	/// </summary>
	/// <param name="repository">The repository for workstations.</param>
	/// <param name="workstationStore">Source of truth for Workstations throughout the application</param>
	/// <param name="logger">The logger.</param>
	public WorkstationsContentVm (
		WorkstationStore workstationStore,
		ILogger? logger = default)
		: base(logger, true) {
		_workstationStore = workstationStore;
	}

	private readonly WorkstationStore _workstationStore;
}