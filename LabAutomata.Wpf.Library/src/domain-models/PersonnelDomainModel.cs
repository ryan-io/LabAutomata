using LabAutomata.DataAccess.response;
using LabAutomata.Db.models;

namespace LabAutomata.Wpf.Library.domain_models {

	public class PersonnelDomainModel : DomainModel<PersonnelResponse> {

		public PersonnelDomainModel (PersonnelResponse response) {
			FirstName = response.FirstName;
			LastName = response.LastName;
			Email = response.Email;
			Location = response.Location;
		}

		public string FirstName {
			get => _firstName;
			set {
				_firstName = value;
				NotifyPropertyChanged();
			}
		}

		public string LastName {
			get => _lastName;
			set {
				_lastName = value;
				NotifyPropertyChanged();
			}
		}

		public string? Email {
			get => _email;
			set {
				_email = value;
				NotifyPropertyChanged();
			}
		}

		public Location? Location {
			get => _location;
			set {
				_location = value;
				NotifyPropertyChanged();
			}
		}

		private string _firstName;
		private string _lastName;
		private string? _email;
		private Location? _location;
	}
}