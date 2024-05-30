using LabAutomata.Db.models;

namespace LabAutomata.Wpf.Library.domain_models {
    public class ManufacturerDomainModel : DomainModel<Manufacturer> {
        private string _name;
        private int _locationId;
        private Location _location;
        private ICollection<WorkRequest> _workRequests;

        public ManufacturerDomainModel () {
        }

        public ManufacturerDomainModel (string name, int locationId, Location location, ICollection<WorkRequest> workRequests) {
            Name = name;
            LocationId = locationId;
            Location = location;
            WorkRequests = workRequests;
        }

        public string Name {
            get => _name;
            set {
                _name = value;
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

        public ICollection<WorkRequest> WorkRequests {
            get => _workRequests;
            set {
                _workRequests = value;
                NotifyPropertyChanged();
            }
        }

        public override Manufacturer Create () {
            return new Manufacturer {
                Name = this.Name,
                LocationId = this.LocationId,
                Location = this.Location,
                WorkRequests = this.WorkRequests
            };
        }

        public override void Validate () {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentNullException(nameof(Name));

            if (LocationId <= 0)
                throw new ArgumentException("LocationId must be greater than 0", nameof(LocationId));

            if (Location == null)
                throw new ArgumentNullException(nameof(Location));
        }
    }
}
