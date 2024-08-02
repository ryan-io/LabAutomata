using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.response;

public record Dht22SensorResponse (int DbId, string Name, string? Description, ICollection<Dht22DataResponse>? Data, EntityState State) {
	public DateTime DateModified { get; } = DateTime.UtcNow;
}