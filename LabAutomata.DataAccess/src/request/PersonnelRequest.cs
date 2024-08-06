using LabAutomata.DataAccess.common;
using LabAutomata.Db.models;

namespace LabAutomata.DataAccess.request;

/// <summary>
/// Requests an already existing Personnel record from the database
/// </summary>
public record PersonnelRequest (int DbId, string FirstName, string LastName, string? Email, Location? Location)
	: RequestResponseBase, IRequest { }

/// <summary>
/// Requests to add a new Personnel record to the database
/// </summary>
public record PersonnelNewRequest (string FirstName, string LastName, string? Email, Location? Location)
	: RequestResponseBase, IRequest { }
