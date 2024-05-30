using LabAutomata.Db.common;
using LabAutomata.Db.models;

namespace LabAutomata.Db.repository;

/// <summary>
/// Represents a repository for managing Location entities in the database.
/// </summary>
public class LocationRepository (ILabPostgreSqlDbContext dbCtx)
    : Repository<Location>(dbCtx, dbCtx.Location);