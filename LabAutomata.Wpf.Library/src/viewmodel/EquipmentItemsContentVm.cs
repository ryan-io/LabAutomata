using LabAutomata.Db.models;
using LabAutomata.Wpf.Library.domain_models;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace LabAutomata.Wpf.Library.viewmodel;

public class EquipmentItemsContentVm : Base {
	public ObservableCollection<EquipmentDomainModel> Equipment { get; set; }

	public override async Task LoadAsync (CancellationToken token = default) {
		//var equipment = await _repository.GetAll(token);
		//List<EquipmentDomainModel> models = new();

		//foreach (var e in equipment) {
		//	var wsdm = new EquipmentDomainModel(e);
		//	models.Add(wsdm);
		//}

		//Equipment = new ObservableCollection<EquipmentDomainModel>(models);
	}

	public EquipmentItemsContentVm (IRepository<Equipment> repository, ILogger? logger = default, bool shouldNotifyErrors = false) : base(logger, shouldNotifyErrors) {
		_repository = repository; ;
	}

	private readonly IRepository<Equipment> _repository;
}