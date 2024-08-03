using LabAutomata.DataAccess.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.response {
	/// <summary>
	/// This is the result of querying the database for Dht22Data and converting
	/// the database model to a domain model
	/// </summary>
	public record Dht22DataResponse (
		int DbId,
		string JsonString,
		Dht22Sensor Dht22Sensor,
		EntityState State = EntityState.Unchanged) : RequestResponseBase {
	}
}
