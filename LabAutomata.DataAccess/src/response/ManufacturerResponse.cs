using LabAutomata.DataAccess.common;
using LabAutomata.DataAccess.request;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.response {
	/// <summary>
	/// This is the result of querying the database for Manufacturer and converting
	/// the database model to a domain model
	/// </summary>
	public record ManufacturerResponse (
		int DbId,
		string Name,
		LocationRequest Location,
		EntityState EntityState)
		: RequestResponseBase;

	/// <summary>
	/// This is the result of querying the database for Manufacturer and converting
	/// the database model to a domain model; this is the result of an add or update
	/// </summary>
	public record ManufacturerUpsertResponse (
		int DbId,
		string Name,
		LocationRequest Location,
		bool WasUpdated)
		: RequestResponseBase;
}
