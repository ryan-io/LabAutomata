using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabAutomata.Db.models;

public class Dht22Data {
	[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; init; }

	[Required, MaxLength(500)]
	public required string JsonString { get; init; }

	[Required]
	public required int Dht22SensorId { get; init; }

	public Dht22Sensor? Dht22Sensor { get; init; }
}
