using LabAutomata.DataAccess.response;

namespace LabAutomata.Wpf.Library.domain_models {

	public class EquipmentDomainModel : DomainModel<EquipmentResponse> {
		public EquipmentDomainModel (EquipmentResponse response) {
			Name = response.Name;
			PurchaseDate = response.PurchaseDate;
			CalibrationDate = response.CalibrationDate;
			CalibrationDueDate = response.CalibrationDueDate;
			Manufacturer = response.Manufacturer;
			//Workstations = equipment.Workstations;
		}

		public string Name {
			get => _name;
			set {
				_name = value;
				NotifyPropertyChanged();
			}
		}

		public DateTime PurchaseDate {
			get => _purchaseDate;
			set {
				_purchaseDate = value;
				NotifyPropertyChanged();
			}
		}

		public DateTime CalibrationDate {
			get => _calibrationDate;
			set {
				_calibrationDate = value;
				NotifyPropertyChanged();
			}
		}

		public DateTime CalibrationDueDate {
			get => _calibrationDueDate;
			set {
				_calibrationDueDate = value;
				NotifyPropertyChanged();
			}
		}

		public ManufacturerResponse Manufacturer {
			get => _manufacturer;
			set {
				_manufacturer = value;
				NotifyPropertyChanged();
			}
		}


		//public ICollection<Workstation> Workstations {
		//	get => _workstations;
		//	set {
		//		_workstations = value;
		//		NotifyPropertyChanged();
		//	}
		//}

		private string _name = null!;
		private DateTime _purchaseDate;
		private DateTime _calibrationDate;
		private DateTime _calibrationDueDate;
		private ManufacturerResponse _manufacturer = ManufacturerResponse.Empty();
		//private ICollection<Workstation> _workstations;
	}
}