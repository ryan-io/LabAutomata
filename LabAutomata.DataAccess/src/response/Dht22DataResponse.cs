using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.response {
	public record Dht22DataResponse (
		int DbId,
		string JsonString,
		Dht22Sensor Dht22Sensor,
		EntityState State = EntityState.Unchanged) {
		public DateTime DateModified { get; } = DateTime.UtcNow;
	}
}
