using LabAutomata.Db.models;
using LabAutomata.Wpf.Library.common;
using System.Collections.ObjectModel;

namespace LabAutomata.Wpf.Library.models {
    /// <summary>
    /// Represents a domain model for a work request.
    /// </summary>
    public class WorkRequestDomainModel : DomainModel<WorkRequest> {
        private string? _name;
        private string? _program;
        private string? _description;
        private DateTime? _startDate;
        private int _testCount;
        private List<string> _obsGetErrors = new();
        private int _wrId;

        public WorkRequestDomainModel () {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkRequestDomainModel"/> class with the specified parameters.
        /// </summary>
        /// <param name="name">The name of the work request.</param>
        /// <param name="program">The program associated with the work request.</param>
        /// <param name="description">The description of the work request.</param>
        /// <param name="startDate">The start date of the work request.</param>
        /// <param name="wrId">Id of the work request</param>
        /// <param name="testCount">Number of tests in the work request</param>
        public WorkRequestDomainModel (string? name,
            string? program,
            string? description,
            DateTime? startDate,
            int wrId,
            int testCount = 0) : base() {
            Name = name;
            Program = program;
            Description = description;
            StartDate = startDate;
            TestCount = testCount;
            WrId = wrId;
        }

        /// <summary>
        /// Resets the properties of the work request domain model to their default values.
        /// </summary>
        public void Reset () {
            Name = string.Empty;
            Description = string.Empty;
            Program = string.Empty;
            StartDate = default;
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
        public int WrId {
            get => _wrId;
            set => _wrId = value;
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

        /// <summary>
        /// Creates a new instance of the <see cref="WorkRequest"/> class based on the properties of the work request domain model.
        /// </summary>
        /// <returns>A new instance of the <see cref="WorkRequest"/> class.</returns>
        public override WorkRequest Create () {
            return new WorkRequest {
                Name = this.Name,
                Program = this.Program,
                Description = this.Description,
                Started = this.StartDate,
                Tests = this.Tests
            };
        }

        /// <summary>
        /// Validates the properties of the work request domain model.
        /// </summary>
        public override void Validate () {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentNullException(Name);

            if (string.IsNullOrWhiteSpace(Program))
                throw new ArgumentNullException(Name);

            //TODO: do we care if description and start date are null and tests is empty?
        }
    }
}
