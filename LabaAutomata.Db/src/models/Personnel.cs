using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {
    public class Personnel : LabModel {
        [Required]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }
    }
}
