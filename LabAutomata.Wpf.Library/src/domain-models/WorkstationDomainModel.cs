using LabAutomata.Db.models;

namespace LabAutomata.Wpf.Library.domain_models {
    public class WorkstationDomainModel : DomainModel<Workstation> {
        private string _name;
        private int _stationNumber;
        private int _locationId;
        private Location _location;
        private ICollection<Test> _tests;
        private string _description;
        private int _testCount;

        // this constructor is intended for data binding
        public WorkstationDomainModel () {

        }

        public WorkstationDomainModel (Workstation ws) {
            Name = ws.Name;
            StationNumber = ws.StationNumber;
            LocationId = ws.LocationId;
            Location = ws.Location;
            Tests = ws.Tests;
            Description = ws.Description;
            TestCount = ws.Tests.Count;
        }

        public WorkstationDomainModel (string name, int stationNumber, int locationId, Location location, ICollection<Test> tests, string description) {
            Name = name;
            StationNumber = stationNumber;
            LocationId = locationId;
            Location = location;
            Tests = tests;
            Description = description;
        }

        public string Name {
            get => _name;
            set {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        public int StationNumber {
            get => _stationNumber;
            set {
                _stationNumber = value;
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

        public ICollection<Test> Tests {
            get => _tests;
            set {
                _tests = value;
                NotifyPropertyChanged();
            }
        }

        public string Description {
            get => _description;
            set {
                _description = value;
                NotifyPropertyChanged();
            }
        }

        public int TestCount {
            get => _testCount;
            set {
                _testCount = value;
                NotifyPropertyChanged();
            }
        }


        public override Workstation Create () {
            return new Workstation {
                Name = this.Name,
                StationNumber = this.StationNumber,
                LocationId = this.LocationId,
                Location = this.Location,
                Tests = this.Tests,
                Description = this.Description
            };
        }

        public override void Validate () {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentNullException(nameof(Name));

            if (StationNumber <= 0)
                throw new ArgumentException("StationNumber must be greater than 0", nameof(StationNumber));

            if (LocationId <= 0)
                throw new ArgumentException("LocationId must be greater than 0", nameof(LocationId));

            if (Location == null)
                throw new ArgumentNullException(nameof(Location));
        }
    }
}

