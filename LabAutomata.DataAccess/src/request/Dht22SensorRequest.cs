using LabAutomata.DataAccess.common;
using LabAutomata.Db.models;

namespace LabAutomata.DataAccess.request;

/// <summary>
/// Requests an already existing Dht22Sensor from the database
/// </summary>
public record Dht22SensorRequest (
	int DbId,
	string Name,
	string? Description,
	LocationRequest Location,
	ICollection<Dht22Data> Data)
	: RequestResponseBase, IRequest;

/// <summary>
/// Requests to add a new Dht22Sensor to the database
/// </summary>
public record Dht22SensorNewRequest (
	string Name,
	string? Description,
	LocationRequest Location)
	: RequestResponseBase, IRequest;