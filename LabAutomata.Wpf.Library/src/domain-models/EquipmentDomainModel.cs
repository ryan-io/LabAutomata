using LabAutomata.Db.models;

namespace LabAutomata.Wpf.Library.domain_models {

	public class EquipmentDomainModel : DomainModel<Equipment> {
		private string _name;
		private DateTime _purchaseDate;
		private DateTime _calibrationDate;
		private DateTime _calibrationDueDate;
		private Manufacturer _manufacturer;
		private int _manufacturerId;
		private ICollection<Workstation> _workstations;

		public EquipmentDomainModel () {
		}

		public EquipmentDomainModel (Equipment equipment) {
			Name = equipment.Name;
			PurchaseDate = equipment.PurchaseDate;
			CalibrationDate = equipment.CalibrationDate;
			CalibrationDueDate = equipment.CalibrationDueDate;
			Manufacturer = equipment.Manufacturer;
			ManufacturerId = equipment.ManufacturerId;
			Workstations = equipment.Workstations;
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

		public Manufacturer Manufacturer {
			get => _manufacturer;
			set {
				_manufacturer = value;
				NotifyPropertyChanged();
			}
		}

		public int ManufacturerId {
			get => _manufacturerId;
			set {
				_manufacturerId = value;
				NotifyPropertyChanged();
			}
		}

		public ICollection<Workstation> Workstations {
			get => _workstations;
			set {
				_workstations = value;
				NotifyPropertyChanged();
			}
		}

		public override Equipment Create () {
			return new Equipment {
				Name = this.Name,
				PurchaseDate = this.PurchaseDate,
				CalibrationDate = this.CalibrationDate,
				CalibrationDueDate = this.CalibrationDueDate,
				Manufacturer = this.Manufacturer,
				ManufacturerId = this.ManufacturerId,
				Workstations = this.Workstations
			};
		}

		public override void Validate () {
			if (string.IsNullOrWhiteSpace(Name))
				throw new ArgumentNullException(nameof(Name));

			if (Manufacturer == null)
				throw new ArgumentNullException(nameof(Manufacturer));

			if (ManufacturerId <= 0)
				throw new ArgumentException("ManufacturerId must be greater than 0", nameof(ManufacturerId));
		}
	}
}