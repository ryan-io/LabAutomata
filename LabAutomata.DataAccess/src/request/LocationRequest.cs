using LabAutomata.DataAccess.common;

namespace LabAutomata.DataAccess.request;

/// <summary>
/// Requests an already existing Location from the database
/// </summary>
public record LocationRequest (
	int DbId,
	string Name,
	string Country,
	string City,
	string State,
	string? Address = "")
	: RequestResponseBase { }

/// <summary>
/// Requests to add a new Location to the database
/// </summary>
public record LocationNewRequest (
	string Name,
	string Country,
	string City,
	string State,
	string? Address = "")
	: RequestResponseBase { }