using LabAutomata.DataAccess.common;
using LabAutomata.Db.models;

namespace LabAutomata.DataAccess.request;

/// <summary>
/// Requests an already existing Equipment from the database
/// </summary>
public record EquipmentRequest (int DbId, string Name, DateTime PurchaseDate, DateTime CalibrationDate, DateTime CalibrationDueDate, Manufacturer Manufacturer)
	: RequestResponseBase { }

/// <summary>
/// Requests to add a new Equipment to the database
/// </summary>
public record EquipmentNewRequest (string Name, DateTime PurchaseDate, DateTime CalibrationDate, DateTime CalibrationDueDate, Manufacturer Manufacturer)
	: RequestResponseBase { }
