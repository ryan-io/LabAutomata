using LabAutomata.DataAccess.response;
using LabAutomata.Db.models;

namespace LabAutomata.Wpf.Library.domain_models {

	public class Dht22DataDomain : DomainModel<Dht22DataResponse> {
		public Dht22DataDomain (Dht22DataResponse response) {
			DbId = response.DbId;
			JsonString = response.JsonString;
			Dht22Sensor = response.Dht22Sensor;
		}

		public Dht22DataDomain (int dbId, string jsonString, Dht22Sensor dht22Sensor) {
			DbId = dbId;
			JsonString = jsonString;
			Dht22Sensor = dht22Sensor;
		}

		public int DbId {
			get => _dbId;
			set {
				_dbId = value;
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

		public Dht22Sensor? Dht22Sensor {
			get => _dht22Sensor;
			set {
				_dht22Sensor = value;
				NotifyPropertyChanged();
			}
		}

		private int _dbId = -1;
		private string _jsonString = "";
		private Dht22Sensor? _dht22Sensor;
	}
}
