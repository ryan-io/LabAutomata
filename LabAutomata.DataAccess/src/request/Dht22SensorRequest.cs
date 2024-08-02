using LabAutomata.Db.models;

namespace LabAutomata.DataAccess.request;

public record Dht22SensorRequest (int Id, string Name, string? Description, ICollection<Dht22Data> Data) {
	public DateTime DateModified { get; } = DateTime.UtcNow;
}

public record Dht22SensorNewRequest (string Name, string? Description) {
	public DateTime DateModified { get; } = DateTime.UtcNow;
}