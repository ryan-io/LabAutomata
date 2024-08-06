using LabAutomata.DataAccess.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.response {
	/// <summary>
	/// This is the result of querying the database for Manufacturer and converting
	/// the database model to a domain model
	/// </summary>
	public record ManufacturerResponse (
		int DbId,
		string Name,
		LocationResponse Location,
		EntityState EntityState)
		: RequestResponseBase, IResponse;

	/// <summary>
	/// This is the result of querying the database for Manufacturer and converting
	/// the database model to a domain model; this is the result of an add or update
	/// </summary>
	public record ManufacturerUpsertResponse (
		int DbId,
		string Name,
		LocationResponse Location,
		bool WasUpdated)
		: RequestResponseBase, IResponse;
}
