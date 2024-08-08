using LabAutomata.DataAccess.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.response;

/// <summary>
/// This is the result of querying the database for Location and converting
/// the database model to a domain model
/// </summary>
public record LocationResponse (
	int DbId,
	string Name,
	string Country,
	string City,
	string State,
	string? Address,
	EntityState EntityState)
	: RequestResponseBase, IResponse {
	public static LocationResponse Empty => new(
		-1,
		"",
		"",
		"",
		"",
		"",
		EntityState.Detached);
}

/// <summary>
/// This is the result of querying the database for Location and converting
/// the database model to a domain model; this is the result of an add or update
/// </summary>
public record LocationUpsertResponse (
	int DbId,
	string Name,
	string Country,
	string City,
	string State,
	string? Address,
	bool WasUpdated)
	: RequestResponseBase, IResponse;