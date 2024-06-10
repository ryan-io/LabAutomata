using LabAutomata.Db.models;
using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Wpf.Library.domain_models {
	public class DhtSensorDomainModel : DomainModel<DhtSensor> {
		private string _sensorName;

		[Required, MaxLength(100)]
		public string SensorName {
			get => _sensorName;
			set {
				if (_sensorName != value) {
					_sensorName = value;
					NotifyPropertyChanged();
				}
			}
		}

		public override DhtSensor Create () {
			return new DhtSensor {
				SensorName = SensorName
			};
		}

		public override void Validate () {
			if (string.IsNullOrWhiteSpace(SensorName)) {
				throw new ArgumentNullException(nameof(SensorName), "SensorName cannot be null or whitespace.");
			}
		}
	}
}
