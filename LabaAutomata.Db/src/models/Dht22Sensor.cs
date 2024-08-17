using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LabAutomata.Db.models;

public class Dht22Sensor {
	[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; init; }

	[Required, MaxLength(100)]
	public required string Name { get; init; }

	[MaxLength(150)]
	public string? Description { get; init; }

	[Required]
	public required Location Location { get; init; }

	[JsonIgnore]
	public ICollection<Dht22Data> Data { get; init; } = new List<Dht22Data>();
}