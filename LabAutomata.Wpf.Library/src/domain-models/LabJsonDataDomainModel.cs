using LabAutomata.Db.models;
using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Wpf.Library.domain_models {

	public class LabJsonDataDomainModel : DomainModel<LabJsonData> {
		private string _jsonString;
		private int _ownerId;

		// this constructor is intended for data binding
		public LabJsonDataDomainModel () {
		}

		public LabJsonDataDomainModel (LabJsonData data) {
			JsonString = data.JsonString;
			OwnerId = data.OwnerId;
		}

		public LabJsonDataDomainModel (string jsonString, int ownerId) {
			JsonString = jsonString;
			OwnerId = ownerId;
		}

		[Required, MaxLength(500)]
		public string JsonString {
			get => _jsonString;
			set {
				_jsonString = value;
				NotifyPropertyChanged();
			}
		}

		[Required]
		public int OwnerId {
			get => _ownerId;
			set {
				_ownerId = value;
				NotifyPropertyChanged();
			}
		}

		public override LabJsonData Create () {
			return new LabJsonData {
				JsonString = this.JsonString,
				OwnerId = this.OwnerId
			};
		}

		public override void Validate () {
			if (string.IsNullOrWhiteSpace(JsonString))
				throw new ArgumentNullException(nameof(JsonString));

			if (JsonString.Length > 500)
				throw new ArgumentException("JsonString must be less than or equal to 500 characters", nameof(JsonString));

			if (OwnerId <= 0)
				throw new ArgumentException("OwnerId must be greater than 0", nameof(OwnerId));
		}
	}
}