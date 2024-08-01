using LabAutomata.Db.models;

namespace LabAutomata.DataAccess.request {
	public record Dht22DataRequest (string JsonString, Dht22Sensor Dht22Sensor) {
		public DateTime DateModified { get; } = DateTime.UtcNow;

		public static Dht22Data NewRequest (Dht22DataRequest request) {
			return new Dht22Data() {
				JsonString = request.JsonString,
				Dht22Sensor = request.Dht22Sensor
			};
		}
	}
}