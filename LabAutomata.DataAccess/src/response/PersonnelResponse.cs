using LabAutomata.DataAccess.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.response;

/// <summary>
/// This is the result of querying the database for Personnel and converting
/// the database model to a domain model
/// </summary>
public record PersonnelResponse (
	int DbId,
	string FirstName,
	string LastName,
	string? Email,
	LocationResponse? Location,
	EntityState State)
	: RequestResponseBase, IResponse { }

/// <summary>
/// This is the result of querying the database for Personnel and converting
/// the database model to a domain model; this is the result of an add or update
/// </summary>
public record PersonnelUpsertResponse (
	int DbId,
	string FirstName,
	string LastName,
	string? Email,
	LocationResponse? Location,
	bool WasUpdated)
	: RequestResponseBase, IResponse { }
