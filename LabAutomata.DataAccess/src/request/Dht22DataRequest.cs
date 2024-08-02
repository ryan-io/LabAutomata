using LabAutomata.Db.models;

namespace LabAutomata.DataAccess.request {
	public record Dht22DataRequest (int Id, string JsonString, Dht22Sensor Dht22Sensor) {
		public DateTime DateModified { get; } = DateTime.UtcNow;
	}

	public record Dht22DataNewRequest (string JsonString, Dht22Sensor Dht22Sensor) {
		public DateTime DateModified { get; } = DateTime.UtcNow;
	}
}