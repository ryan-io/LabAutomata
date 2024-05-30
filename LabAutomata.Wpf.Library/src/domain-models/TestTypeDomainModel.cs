using LabAutomata.Db.models;

namespace LabAutomata.Wpf.Library.domain_models {
    public class TestTypeDomainModel : DomainModel<TestType> {
        private string _name;
        private int _bitId;

        public TestTypeDomainModel () {
        }

        public TestTypeDomainModel (string name, int bitId) {
            Name = name;
            BitId = bitId;
        }

        public string Name {
            get => _name;
            set {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        public int BitId {
            get => _bitId;
            set {
                _bitId = value;
                NotifyPropertyChanged();
            }
        }

        public override TestType Create () {
            return new TestType {
                Name = this.Name,
                BitId = this.BitId
            };
        }

        public override void Validate () {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentNullException(nameof(Name));

            if (BitId <= 0)
                throw new ArgumentException("BitId must be greater than 0", nameof(BitId));
        }
    }
}

