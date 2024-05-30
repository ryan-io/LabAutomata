using LabAutomata.Db.models;

namespace LabAutomata.Wpf.Library.domain_models {
    public class PersonnelDomainModel : DomainModel<Personnel> {
        private string _firstName;
        private string _lastName;
        private string _email;
        private int _locationId;
        private Location _location;

        public PersonnelDomainModel () {
        }

        public PersonnelDomainModel (string firstName, string lastName, string email, int locationId, Location location) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            LocationId = locationId;
            Location = location;
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

        public string Email {
            get => _email;
            set {
                _email = value;
                NotifyPropertyChanged();
            }
        }

        public int LocationId {
            get => _locationId;
            set {
                _locationId = value;
                NotifyPropertyChanged();
            }
        }

        public Location Location {
            get => _location;
            set {
                _location = value;
                NotifyPropertyChanged();
            }
        }

        public override Personnel Create () {
            return new Personnel {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                LocationId = this.LocationId,
                Location = this.Location
            };
        }

        public override void Validate () {
            if (string.IsNullOrWhiteSpace(FirstName))
                throw new ArgumentNullException(nameof(FirstName));

            if (string.IsNullOrWhiteSpace(LastName))
                throw new ArgumentNullException(nameof(LastName));

            if (string.IsNullOrWhiteSpace(Email))
                throw new ArgumentNullException(nameof(Email));

            if (LocationId <= 0)
                throw new ArgumentException("LocationId must be greater than 0", nameof(LocationId));

            if (Location == null)
                throw new ArgumentNullException(nameof(Location));
        }
    }
}
