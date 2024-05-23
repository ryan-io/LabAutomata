using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {
    public class WorkRequest : LabModel {
        [Required, MaxLength(100)]
        public string? Name { get; set; } = string.Empty;

        [Required, MaxLength(100)] public string? Program { get; set; } = string.Empty;

        [MaxLength(225)]
        public string? Description { get; set; } = string.Empty;
        public DateTime? Started { get; set; }
        public DateTime? Finished { get; set; }
        // navigation property for tests
        public ICollection<Test>? Tests { get; set; } = new HashSet<Test>();
    }
}
