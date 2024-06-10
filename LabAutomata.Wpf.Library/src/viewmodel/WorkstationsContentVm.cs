using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Wpf.Library.domain_models;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace LabAutomata.Wpf.Library.viewmodel;

/// <summary>
/// Represents the view model for the WorkstationsContent view.
/// </summary>
public class WorkstationsContentVm : Base {

	/// <summary>
	/// Gets or sets the collection of workstations.
	/// </summary>
	public ObservableCollection<WorkstationDomainModel> Workstations { get; set; } = new();

	public override async Task LoadAsync (CancellationToken token = default) {
		var workstations = await _repository.GetAll(token);
		List<WorkstationDomainModel> models = new();

		foreach (var ws in workstations) {
			var wsdm = new WorkstationDomainModel(ws);
			models.Add(wsdm);
		}

		Workstations = new ObservableCollection<WorkstationDomainModel>(models);
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="WorkstationsContentVm"/> class.
	/// </summary>
	/// <param name="repository">The repository for workstations.</param>
	/// <param name="logger">The logger.</param>
	public WorkstationsContentVm (IRepository<Workstation> repository, ILogger? logger = default) : base(logger, true) {
		_repository = repository;
	}

	private readonly IRepository<Workstation> _repository;
}