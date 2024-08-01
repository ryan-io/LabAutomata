using LabAutomata.Db.models;
using System.Collections.ObjectModel;

namespace LabAutomata.Wpf.Library.domain_models {
	//TODO: this model needs to be dependent on DhtJsonDataDomainModel
	//		and should convert all DhtJsonData to DhtJsonDataDomainModel
	public class DhtSensorDomainModel : DomainModel<Dht22Sensor> {
		private int _id = -1;
		private string _sensorName = "";
		private string? _description = "";

		// this constructor is intended for data binding
		public DhtSensorDomainModel () {
			Data = new ObservableCollection<DhtJsonDataDomainModel>();
		}

		public DhtSensorDomainModel (Dht22Sensor sensor) {
			Id = sensor.Id;
			SensorName = sensor.SensorName;
			Description = sensor.Description;

			Data = new ObservableCollection<DhtJsonDataDomainModel>();

			if (sensor.Data.Count > 0) {
				foreach (var dhtJsonData in sensor.Data) {
					Data.Add(new DhtJsonDataDomainModel(dhtJsonData));
				}
			}
		}

		public DhtSensorDomainModel (int id, string sensorName, string description) {
			Id = id;
			SensorName = sensorName;
			Description = description;
			Data = new ObservableCollection<DhtJsonDataDomainModel>();
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

		public ObservableCollection<DhtJsonDataDomainModel> Data { get; set; }

		public override Dht22Sensor Create () {
			return new Dht22Sensor {
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