using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {
    public class Personnel : LabModel {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }
    }
}