using LabAutomata.Db.models;

namespace LabAutomata.Wpf.Library.domain_models {
    public class TestDomainModel : DomainModel<Test> {
        private string _name;
        private int _wrId;
        private int _instanceId;
        private int _typeId;
        private int _locationId;
        private int _operatorId;
        private DateTime? _started;
        private DateTime? _ended;

        public TestDomainModel () {
        }

        public TestDomainModel (string name, int wrId, int instanceId, int typeId, int locationId, int operatorId, DateTime? started, DateTime? ended) {
            Name = name;
            WrId = wrId;
            InstanceId = instanceId;
            TypeId = typeId;
            LocationId = locationId;
            OperatorId = operatorId;
            Started = started;
            Ended = ended;
        }

        public string Name {
            get => _name;
            set {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        public int WrId {
            get => _wrId;
            set {
                _wrId = value;
                NotifyPropertyChanged();
            }
        }

        public int InstanceId {
            get => _instanceId;
            set {
                _instanceId = value;
                NotifyPropertyChanged();
            }
        }

        public int TypeId {
            get => _typeId;
            set {
                _typeId = value;
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

        public int OperatorId {
            get => _operatorId;
            set {
                _operatorId = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime? Started {
            get => _started;
            set {
                _started = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime? Ended {
            get => _ended;
            set {
                _ended = value;
                NotifyPropertyChanged();
            }
        }

        public override Test Create () {
            return new Test {
                Name = Name,
                WrId = WrId,
                InstanceId = InstanceId,
                TypeId = TypeId,
                LocationId = LocationId,
                OperatorId = OperatorId,
                Started = Started,
                Ended = Ended
            };
        }

        public override void Validate () {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentNullException(nameof(Name));

            if (WrId <= 0)
                throw new ArgumentException("WrId must be greater than 0", nameof(WrId));

            if (InstanceId <= 0)
                throw new ArgumentException("InstanceId must be greater than 0", nameof(InstanceId));

            if (TypeId <= 0)
                throw new ArgumentException("TypeId must be greater than 0", nameof(TypeId));

            if (LocationId <= 0)
                throw new ArgumentException("LocationId must be greater than 0", nameof(LocationId));

            if (OperatorId <= 0)
                throw new ArgumentException("OperatorId must be greater than 0", nameof(OperatorId));
        }
    }
}
