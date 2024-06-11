using LabAutomata.Db.models;

namespace LabAutomata.Wpf.Library.domain_models {
	//TODO: this model needs to be dependent on DhtJsonDataDomainModel
	//		and should convert all DhtJsonData to DhtJsonDataDomainModel
	public class DhtSensorDomainModel : DomainModel<DhtSensor> {
		private int _id;
		private string _sensorName;
		private string? _description;

		// this constructor is intended for data binding
		public DhtSensorDomainModel () {
		}

		public DhtSensorDomainModel (DhtSensor sensor) {
			Id = sensor.Id;
			SensorName = sensor.SensorName;
			Description = sensor.Description;
		}

		public DhtSensorDomainModel (int id, string sensorName, string description) {
			Id = id;
			SensorName = sensorName;
			Description = description;
		}

		//public ICollection<DhtJsonData> Data {
		//	get => _data;
		//	set {
		//		_data = value;
		//		NotifyPropertyChanged();
		//	}
		//}

		public int Id {
			get => _id;
			set {
				_id = value;
				NotifyPropertyChanged();
			}
		}

		public string SensorName {
			get => _sensorName;
			set {
				_sensorName = value;
				NotifyPropertyChanged();
			}
		}


		public string? Description {
			get => _description;
			set {
				_description = value;
				NotifyPropertyChanged();
			}
		}

		public override DhtSensor Create () {
			return new DhtSensor {
				Id = Id,
				SensorName = SensorName,
				Description = Description,
			};
		}

		public override void Validate () {
			if (string.IsNullOrWhiteSpace(SensorName))
				throw new ArgumentNullException(nameof(SensorName));
		}
	}
}