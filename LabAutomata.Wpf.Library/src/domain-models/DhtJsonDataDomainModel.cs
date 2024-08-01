using LabAutomata.Db.models;

namespace LabAutomata.Wpf.Library.domain_models {

	public class DhtJsonDataDomainModel : DomainModel<Dht22Data> {
		private int _id = -1;
		private string _jsonString = "";
		private int _dhtSensorId = -1;
		private Dht22Sensor? _dht22Sensor = default;

		// this constructor is intended for data binding
		public DhtJsonDataDomainModel () {
		}

		public DhtJsonDataDomainModel (Dht22Data data) {
			Id = data.Id;
			JsonString = data.JsonString;
			DhtSensorId = data.DhtSensorId;
			Dht22Sensor = data.Dht22Sensor;
		}

		public DhtJsonDataDomainModel (int id, string jsonString, int dhtSensorId, Dht22Sensor dht22Sensor) {
			Id = id;
			JsonString = jsonString;
			DhtSensorId = dhtSensorId;
			Dht22Sensor = dht22Sensor;
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

		public Dht22Sensor? Dht22Sensor {
			get => _dht22Sensor;
			set {
				_dht22Sensor = value;
				NotifyPropertyChanged();
			}
		}

		public override Dht22Data Create () {
			return new Dht22Data {
				Id = Id,
				JsonString = JsonString,
				DhtSensorId = DhtSensorId,
				Dht22Sensor = Dht22Sensor!
			};
		}

		public override void Validate () {
			ArgumentException.ThrowIfNullOrWhiteSpace(JsonString);
			ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(0, DhtSensorId, "DhtSensorId");
			ArgumentNullException.ThrowIfNull(Dht22Sensor);
		}
	}
}
