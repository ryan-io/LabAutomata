using LabAutomata.Db.models;

namespace LabAutomata.Wpf.Library.domain_models {

	public class LocationDomainModel : DomainModel<Location> {
		private string _name;
		private string _address;
		private string _city;
		private string _state;
		private string _country;

		public LocationDomainModel () {
		}

		public LocationDomainModel (string name, string address, string city, string state, string country) {
			Name = name;
			Address = address;
			City = city;
			State = state;
			Country = country;
		}

		public string Name {
			get => _name;
			set {
				_name = value;
				NotifyPropertyChanged();
			}
		}

		public string Address {
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

		public override Location Create () {
			return new Location {
				Name = this.Name,
				Address = this.Address,
				City = this.City,
				State = this.State,
				Country = this.Country
			};
		}

		public override void Validate () {
			if (string.IsNullOrWhiteSpace(Name))
				throw new ArgumentNullException(nameof(Name));

			if (string.IsNullOrWhiteSpace(Address))
				throw new ArgumentNullException(nameof(Address));

			if (string.IsNullOrWhiteSpace(City))
				throw new ArgumentNullException(nameof(City));

			if (string.IsNullOrWhiteSpace(State))
				throw new ArgumentNullException(nameof(State));

			if (string.IsNullOrWhiteSpace(Country))
				throw new ArgumentNullException(nameof(Country));
		}
	}
}