using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models;

public class Manufacturer {

	[Required, MaxLength(100)]
	public string? Name { get; init; } = string.Empty;

	public int LocationId { get; init; }

	public Location Location { get; init; }

	public ICollection<WorkRequest> WorkRequests { get; init; }
}