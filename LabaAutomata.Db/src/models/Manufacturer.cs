using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models;

public class Manufacturer {
	public int Id { get; set; }

	[Required, MaxLength(100)]
	public required string Name { get; set; }

	[Required] public required int LocationId { get; set; }

	[Required]
	public required Location Location { get; set; }
}