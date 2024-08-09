using LabAutomata.DataAccess.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.response;

/// <summary>
/// This is the result of querying the database for Equipment and converting
/// the database model to a domain model
/// </summary>
public record EquipmentResponse (
	int DbId,
	string Name,
	DateTime PurchaseDate,
	DateTime CalibrationDate,
	DateTime CalibrationDueDate,
	ManufacturerResponse Manufacturer,
	EntityState State)
	: RequestResponseBase, IResponse { }

/// <summary>
/// This is the result of querying the database for Equipment and converting
/// the database model to a domain model; this is the result of an add or update
/// </summary>
public record EquipmentUpsertResponse (
	int DbId,
	string Name,
	DateTime PurchaseDate,
	DateTime CalibrationDate,
	DateTime CalibrationDueDate,
	ManufacturerResponse Manufacturer,
	bool WasUpdated)
	: RequestResponseBase, IResponse { }
