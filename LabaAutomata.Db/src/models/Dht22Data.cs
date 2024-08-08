using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models;

public class Dht22Data {
	public int Id { get; set; }

	[Required, MaxLength(500)]
	public required string JsonString { get; set; }

	[Required]
	public required int Dht22SensorId { get; set; }

	[Required]
	public required Dht22Sensor Dht22Sensor { get; set; }
}
