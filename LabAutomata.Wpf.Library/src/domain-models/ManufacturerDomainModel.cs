using LabAutomata.DataAccess.response;

namespace LabAutomata.Wpf.Library.domain_models {

	public class ManufacturerDomainModel : DomainModel<ManufacturerResponse> {
		public ManufacturerDomainModel (ManufacturerResponse response) {
			Name = response.Name;
			Location = response.Location;
			//WorkRequests = workRequests;
		}

		public string Name {
			get => _name;
			set {
				_name = value;
				NotifyPropertyChanged();
			}
		}

		public LocationResponse Location {
			get => _location;
			set {
				_location = value;
				NotifyPropertyChanged();
			}
		}

		//public ICollection<WorkRequestResponse> WorkRequests {
		//	get => _workRequests;
		//	set {
		//		_workRequests = value;
		//		NotifyPropertyChanged();
		//	}
		//}

		private string _name;
		private LocationResponse _location;
		//private ICollection<WorkRequest> _workRequests;
	}
}