using LabAutomata.Db.common;
using LabAutomata.Db.models;

namespace LabAutomata.Db.repository;

/// <summary>
/// Represents a repository for managing Work Request entities in the database.
/// </summary>
public class SeedDataRepository (ILabPostgreSqlDbContext dbCtx)
    : Repository<SeedJson>(dbCtx, dbCtx.SeedJson);