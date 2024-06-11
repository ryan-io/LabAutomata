using LabAutomata.Db.models;

namespace LabAutomata.Wpf.Library.domain_models {

	public class DhtJsonDataDomainModel : DomainModel<DhtJsonData> {
		private int _id;
		private string _jsonString;
		private int _dhtSensorId;
		private DhtSensor _dhtSensor;

		// this constructor is intended for data binding
		public DhtJsonDataDomainModel () {
		}

		public DhtJsonDataDomainModel (DhtJsonData data) {
			Id = data.Id;
			JsonString = data.JsonString;
			DhtSensorId = data.DhtSensorId;
			DhtSensor = data.DhtSensor;
		}

		public DhtJsonDataDomainModel (int id, string jsonString, int dhtSensorId, DhtSensor dhtSensor) {
			Id = id;
			JsonString = jsonString;
			DhtSensorId = dhtSensorId;
			DhtSensor = dhtSensor;
		}

		public int Id {
			get => _id;
			set {
				_id = value;
				NotifyPropertyChanged();
			}
		}

		public string JsonString {
			get => _jsonString;
			set {
				_jsonString = value;
				NotifyPropertyChanged();
			}
		}

		public int DhtSensorId {
			get => _dhtSensorId;
			set {
				_dhtSensorId = value;
				NotifyPropertyChanged();
			}
		}

		public DhtSensor DhtSensor {
			get => _dhtSensor;
			set {
				_dhtSensor = value;
				NotifyPropertyChanged();
			}
		}

		public override DhtJsonData Create () {
			return new DhtJsonData {
				Id = this.Id,
				JsonString = this.JsonString,
				DhtSensorId = this.DhtSensorId,
				DhtSensor = this.DhtSensor
			};
		}

		public override void Validate () {
			ArgumentException.ThrowIfNullOrWhiteSpace(JsonString);
			ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(0, DhtSensorId, "DhtSensorId");
			ArgumentNullException.ThrowIfNull(DhtSensor);
		}
	}
}
