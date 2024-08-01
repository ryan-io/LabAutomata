using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.response {
	public record Dht22DataResponse (
		int DbId,
		string JsonString,
		Dht22Sensor Dht22Sensor,
		EntityState State = EntityState.Unchanged,
		bool HadErrors = false) {
		public DateTime DateModified { get; } = DateTime.UtcNow;

		public static Dht22DataResponse NewResponse (
			Dht22Data data,
			EntityState state = EntityState.Unchanged,
			bool hadErrors = false) {
			return new Dht22DataResponse(
				data.Id,
				data.JsonString,
				data.Dht22Sensor,
				state,
				hadErrors);
		}
	}
}
