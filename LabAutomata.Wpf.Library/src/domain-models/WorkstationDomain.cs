using LabAutomata.DataAccess.response;
using LabAutomata.Db.models;

namespace LabAutomata.Wpf.Library.domain_models {
	public class WorkstationDomain : DomainModel<WorkstationResponse> {

		public WorkstationDomain (WorkstationResponse response) {
			Name = response.Name;
			StationNumber = response.StationNumber;
			Location = response.Location;
			Description = response.Description;
			//TestCount = ws.Tests.Count;
			//Tests = ws.Tests;
			//Types = ws.Types;
			//Equipment = ws.Equipment;
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

		public LocationResponse? Location {
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

		public ICollection<Equipment> Equipment {
			get => _equipment;
			set {
				_equipment = value;
				NotifyPropertyChanged();
			}
		}

		public ICollection<WorkstationType> Types {
			get => _types;
			set {
				_types = value;
				NotifyPropertyChanged();
			}
		}

		public string? Description {
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

		private string _name;
		private int _stationNumber;
		private string? _description;
		private LocationResponse? _location;
		private ICollection<Test> _tests;
		private ICollection<WorkstationType> _types;
		private ICollection<Equipment> _equipment;
		private int _testCount;
	}
}