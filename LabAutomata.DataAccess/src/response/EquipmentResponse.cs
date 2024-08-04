using LabAutomata.DataAccess.common;
using LabAutomata.Db.models;
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
	Manufacturer Manufacturer,
	EntityState State)
	: RequestResponseBase { }

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
	Manufacturer Manufacturer,
	bool WasUpdated)
	: RequestResponseBase { }
