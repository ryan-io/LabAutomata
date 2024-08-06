using LabAutomata.DataAccess.response;

namespace LabAutomata.Wpf.Library.domain_models {

	public class LocationDomainModel : DomainModel<LocationResponse> {
		public LocationDomainModel (LocationResponse response) {
			Name = response.Name;
			Address = response.Address;
			City = response.City;
			State = response.State;
			Country = response.Country;
		}

		public string Name {
			get => _name;
			set {
				_name = value;
				NotifyPropertyChanged();
			}
		}

		public string? Address {
			get => _address;
			set {
				_address = value;
				NotifyPropertyChanged();
			}
		}

		public string City {
			get => _city;
			set {
				_city = value;
				NotifyPropertyChanged();
			}
		}

		public string State {
			get => _state;
			set {
				_state = value;
				NotifyPropertyChanged();
			}
		}

		public string Country {
			get => _country;
			set {
				_country = value;
				NotifyPropertyChanged();
			}
		}

		private string _name;
		private string _city;
		private string _state;
		private string _country;
		private string? _address;
	}
}