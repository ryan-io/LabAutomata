using LabAutomata.Db.models;

namespace LabAutomata.Wpf.Library.models {
    /// <summary>
    /// Represents a domain model for a work request.
    /// </summary>
    public class WorkRequestDomainModel : DomainModel<WorkRequest> {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkRequestDomainModel"/> class.
        /// </summary>
        public WorkRequestDomainModel () {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkRequestDomainModel"/> class with the specified parameters.
        /// </summary>
        /// <param name="name">The name of the work request.</param>
        /// <param name="program">The program associated with the work request.</param>
        /// <param name="description">The description of the work request.</param>
        /// <param name="startDate">The start date of the work request.</param>
        /// <param name="tests">The collection of tests associated with the work request.</param>
        public WorkRequestDomainModel (string? name,
            string? program,
            string? description,
            DateTime? startDate,
            ICollection<Test>? tests) {
            Name = name;
            Program = program;
            Description = description;
            StartDate = startDate;
            Tests = tests;
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
        }

        /// <summary>
        /// Gets or sets the name of the work request.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the program associated with the work request.
        /// </summary>
        public string? Program { get; set; }

        /// <summary>
        /// Gets or sets the description of the work request.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the start date of the work request.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the collection of tests associated with the work request.
        /// </summary>
        public ICollection<Test>? Tests { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="WorkRequest"/> class based on the properties of the work request domain model.
        /// </summary>
        /// <returns>A new instance of the <see cref="WorkRequest"/> class.</returns>
        protected override WorkRequest Create () {
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
        protected override void Validate () {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentNullException(Name);

            if (string.IsNullOrWhiteSpace(Program))
                throw new ArgumentNullException(Name);

            //TODO: do we care if description and start date are null and tests is empty?
        }
    }
}
