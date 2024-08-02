using LabAutomata.DataAccess.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.response;

public record LocationResponse (
	int DbId,
	string Name,
	string Country,
	string City,
	string State,
	string? Address,
	EntityState EntityState)
	: RequestResponseBase { }

public record LocationUpsertResponse (
	int DbId,
	string Name,
	string Country,
	string City,
	string State,
	string? Address,
	bool WasUpdated)
	: RequestResponseBase { }