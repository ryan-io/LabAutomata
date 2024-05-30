using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {
    public class WorkRequest : LabModel {
        [Required]
        public int WrId { get; set; }

        [Required, MaxLength(100)]
        public string? Name { get; set; } = string.Empty;

        [Required, MaxLength(100)] public string? Program { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Description { get; set; } = string.Empty;

        [Required]
        public Manufacturer Manufacturer { get; set; }

        public int ManufacturerId { get; set; }

        public DateTime? Started { get; set; }
        public DateTime? Finished { get; set; }
        // navigation property for tests
        public ICollection<Test>? Tests { get; set; }
    }
}
