using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models;

public class Dht22Sensor {
	public int Id { get; init; }

	[Required, MaxLength(100)]
	public required string Name { get; init; }

	[MaxLength(150)]
	public string? Description { get; init; }

	[Required]
	public required Location Location { get; init; }

	public ICollection<Dht22Data>? Data { get; init; }
}