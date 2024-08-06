using LabAutomata.DataAccess.response;
using LabAutomata.Db.models;
using System.Collections.ObjectModel;

namespace LabAutomata.Wpf.Library.domain_models {
	public class Dht22SensorDomain : DomainModel<Dht22SensorResponse> {
		public Dht22SensorDomain (Dht22SensorResponse response) {
			DbId = response.DbId;
			SensorName = response.Name;
			Description = response.Description;
			Location = response.Location;

			Data = new ObservableCollection<Dht22DataDomain>();

			if (response.Data is { Count: > 0 }) {
				foreach (var data in response.Data) {
					Data.Add(new Dht22DataDomain(data));
				}
			}
		}

		//public ICollection<DhtJsonData> Data {
		//	get => _data;
		//	set {
		//		_data = value;
		//		NotifyPropertyChanged();
		//	}
		//}

		public Location? Location {
			get => _location;
			set {
				_location = value;
				NotifyPropertyChanged();
			}
		}


		public int DbId {
			get => _dbId;
			set {
				_dbId = value;
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

		public ObservableCollection<Dht22DataDomain> Data { get; set; }

		private int _dbId = -1;
		private string _sensorName = "";
		private string? _description = "";
		private Location? _location;

	}
}