using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models;

public class Manufacturer : LabModel {
    [Required, MaxLength(100)]
    public string? Name { get; set; } = string.Empty;

    public ICollection<WorkRequest> WorkRequests { get; set; }
}