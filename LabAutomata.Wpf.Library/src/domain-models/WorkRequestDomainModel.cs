using LabAutomata.DataAccess.response;
using LabAutomata.Db.models;
using LabAutomata.Wpf.Library.common;
using System.Collections.ObjectModel;

namespace LabAutomata.Wpf.Library.domain_models {

	/// <summary>
	/// Represents a domain model for a work request.
	/// </summary>
	public class WorkRequestDomainModel : DomainModel<WorkRequestResponse> {
		/// <summary>
		/// Initializes a new instance of the <see cref="WorkRequestDomainModel"/> class with the specified parameters.
		/// </summary>
		public WorkRequestDomainModel (WorkRequestResponse response) : base() {
			Name = response.Name;
			RequestId = response.RequestId;
			Program = response.Program;
			Description = response.Description;
			StartDate = response.Started;
			FinishDate = response.Finished;
		}

		/// <summary>
		/// Resets the properties of the work request domain model to their default values.
		/// </summary>
		public void Reset () {
			Name = string.Empty;
			Description = string.Empty;
			Program = string.Empty;
			StartDate = default;
			FinishDate = default;
			Tests?.Clear();
			ClearAllErrors();
		}

		/// <summary>
		/// Gets or sets the name of the work request.
		/// </summary>
		public string? Name {
			get => _name;
			set {
				_name = value;

				if (string.IsNullOrWhiteSpace(_name))
					AddError(WpfLibC.Msg.WrDomainNameIsNull);
				else
					RemoveErrorsFor();

				ObsGetErrors = GetErrorsList();
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the program associated with the work request.
		/// </summary>
		public string? Program {
			get => _program;
			set {
				_program = value;

				if (string.IsNullOrWhiteSpace(_program))
					AddError(WpfLibC.Msg.WrDomainProgramIsNull);
				else
					RemoveErrorsFor();

				ObsGetErrors = GetErrorsList();
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the description of the work request.
		/// </summary>
		public string? Description {
			get => _description;
			set {
				_description = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the WrId.
		/// </summary>
		public int RequestId {
			get => _requestId;
			set => _requestId = value;
		}

		public Manufacturer Manufacturer {
			get => _manufacturer;
			set {
				_manufacturer = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the start date of the work request.
		/// </summary>
		public DateTime? StartDate {
			get => _startDate;
			set {
				_startDate = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the end date of the work request.
		/// </summary>
		public DateTime? FinishDate {
			get => _finishDate;
			set {
				_finishDate = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the test count of the work request.
		/// </summary>
		public int TestCount {
			get => _testCount;
			set {
				_testCount = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the collection of tests associated with the work request.
		/// </summary>
		public ObservableCollection<Test>? Tests { get; set; } = [];

		/// <summary>
		///  Gets a list of errors
		/// </summary>
		/// <returns>A list of errors...</returns>
		public List<string> ObsGetErrors {
			get => _obsGetErrors;
			set {
				_obsGetErrors = value;
				NotifyPropertyChanged();
			}
		}

		private string _name;
		private string _program;
		private string? _description;
		private int _requestId;
		private int _testCount;
		private DateTime? _startDate;
		private DateTime? _finishDate;
		private Manufacturer? _manufacturer;
		private List<string> _obsGetErrors = new();
	}
}