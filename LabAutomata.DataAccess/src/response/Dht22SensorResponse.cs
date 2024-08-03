using LabAutomata.DataAccess.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.response;

/// <summary>
/// This is the result of querying the database for Dht22Sensor and converting
/// the database model to a domain model
/// </summary>
public record Dht22SensorResponse (
	int DbId,
	string Name,
	string? Description,
	ICollection<Dht22DataResponse>? Data,
	EntityState State)
	: RequestResponseBase { }

/// <summary>
/// This is the result of querying the database for Dht22Sensor and converting
/// the database model to a domain model; this is the result of an add or update
/// </summary>
public record Dht22SensorUpsertResponse (
	int DbId,
	string Name,
	string? Description,
	ICollection<Dht22DataResponse>? Data,
	bool WasUpdated)
	: RequestResponseBase { }