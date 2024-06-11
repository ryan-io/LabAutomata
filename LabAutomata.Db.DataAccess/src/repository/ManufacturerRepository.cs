using LabAutomata.Db.common;
using LabAutomata.Db.models;

namespace LabAutomata.Db.DataAccess.src.repository;

/// <summary>
/// Represents a repository for managing Manufacturer entities in the database.
/// </summary>
public class ManufacturerRepository (ILabPostgreSqlDbContext dbCtx)
	: Repository<Manufacturer>(dbCtx, dbCtx.Manufacturers);