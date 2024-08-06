using LabAutomata.DataAccess.service;
using LabAutomata.Wpf.Library.domain_models;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace LabAutomata.Wpf.Library.viewmodel;

public interface IWorkRequestContentVm {
	ObservableCollection<WorkRequestDomainModel> WorkRequests { get; set; }
}

/// <summary>
/// Represents a view model for the work request content.
/// </summary>
public class WorkRequestContentVm : Base, IWorkRequestContentVm {

	/// <summary>
	/// Gets or sets the collection of work requests.
	/// </summary>
	public ObservableCollection<WorkRequestDomainModel> WorkRequests { get; set; } = new();

	/// <summary>
	/// Loads the work requests asynchronously.
	/// </summary>
	/// <param name="token">The cancellation token.</param>
	/// <returns>A task representing the asynchronous operation.</returns>
	public override async Task LoadAsync (CancellationToken token = default) {
		//var wrs = await _repository.GetAll(token);
		//List<WorkRequestDomainModel> models = new();

		//foreach (var wr in wrs) {
		//	var count = wr.Tests?.Count ?? 0;
		//	var wrdm = new WorkRequestDomainModel(wr.Name, wr.Program, wr.Description, wr.Started, wr.WrId, wr.Manufacturer, count);
		//	models.Add(wrdm);
		//}

		//WorkRequests = new ObservableCollection<WorkRequestDomainModel>(models);
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="WorkRequestContentVm"/> class.
	/// </summary>
	/// <param name="service">The repository for work requests.</param>
	/// <param name="logger">The logger.</param>
	public WorkRequestContentVm (IWorkRequestService service, ILogger? logger = default) : base(logger, true) {
		_service = service;
	}

	private readonly IWorkRequestService _service;
}