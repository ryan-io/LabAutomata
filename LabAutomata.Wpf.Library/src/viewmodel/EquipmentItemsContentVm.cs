using LabAutomata.DataAccess.service;
using LabAutomata.Wpf.Library.domain_models;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace LabAutomata.Wpf.Library.viewmodel;

public class EquipmentItemsContentVm : Base {
	public ObservableCollection<EquipmentDomainModel> Equipment { get; set; } = null!;

	//TODO: implement this method properly
	public override Task LoadAsync (CancellationToken token = default) {
		//var equipment = await _repository.GetAll(token);
		//List<EquipmentDomainModel> models = new();

		//foreach (var e in equipment) {
		//	var wsdm = new EquipmentDomainModel(e);
		//	models.Add(wsdm);
		//}

		//Equipment = new ObservableCollection<EquipmentDomainModel>(models);
		return Task.CompletedTask;
	}

	public EquipmentItemsContentVm (IEquipmentService service, ILogger? logger = default, bool shouldNotifyErrors = false) : base(logger, shouldNotifyErrors) {
		_service = service; ;
	}

	private readonly IEquipmentService _service;
}