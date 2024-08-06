using LabAutomata.DataAccess.common;
using LabAutomata.Db.models;
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
	Location? Location,
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
	Location? Location,
	bool WasUpdated)
	: RequestResponseBase, IResponse { }
