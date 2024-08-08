using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models;

public class Dht22Sensor {
	public int Id { get; set; }

	[Required, MaxLength(100)]
	public required string Name { get; set; }

	[MaxLength(150)]
	public string? Description { get; set; }

	[Required]
	public required Location Location { get; set; }

	public ICollection<Dht22Data> Data { get; set; } = new List<Dht22Data>();
}