using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models;

public class Manufacturer {
	public int Id { get; init; }

	[Required, MaxLength(100)]
	public required string Name { get; init; }

	//[Required] public required int LocationId { get; init; }

	[Required]
	public required Location Location { get; init; }
}