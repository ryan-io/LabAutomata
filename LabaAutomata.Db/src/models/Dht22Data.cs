using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models;

public class Dht22Data {
	public int Id { get; init; }

	[Required, MaxLength(500)]
	public required string JsonString { get; init; }

	[Required]
	public required Dht22Sensor Dht22Sensor { get; init; }
}
