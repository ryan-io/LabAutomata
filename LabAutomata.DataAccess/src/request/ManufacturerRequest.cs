using LabAutomata.DataAccess.common;

namespace LabAutomata.DataAccess.request;
/// <summary>
/// Requests an already existing Manufacturer from the database
/// </summary>
public record ManufacturerRequest (int DbId, string Name, LocationRequest Location)
	: RequestResponseBase, IRequest;


/// <summary>
/// Requests to add a new Manufacturer to the database
/// </summary>
public record ManufacturerNewRequest (string Name, LocationRequest Location)
	: RequestResponseBase, IRequest;