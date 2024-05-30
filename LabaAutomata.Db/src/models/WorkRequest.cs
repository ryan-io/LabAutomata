using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabAutomata.Db.models {
    [Table("work_requests")]
    public class WorkRequest : LabModel {
        public int WrId { get; set; }

        [Required, MaxLength(100)]
        public string? Name { get; set; } = string.Empty;

        [Required, MaxLength(100)] public string? Program { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Description { get; set; } = string.Empty;

        public Manufacturer Manufacturer { get; set; }

        public int ManufacturerId { get; set; }

        public DateTime? Started { get; set; }
        public DateTime? Finished { get; set; }
        // navigation property for tests
        public ICollection<Test>? Tests { get; set; }
    }
}
