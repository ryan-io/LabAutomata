using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.Db.repository {
    /// <summary>
    /// Represents a repository for managing Work Request entities in the database.
    /// </summary>
    public class WorkRequestsRepository (ILabPostgreSqlDbContext dbCtx, DbSet<WorkRequest> set)
        : Repository<WorkRequest>(dbCtx, set);

    /// <summary>
    /// Represents a repository for managing SteadyStateTemperatureTest entities in the database.
    /// </summary>
    public class SsTemperatureRepository (ILabPostgreSqlDbContext dbCtx, DbSet<SteadyStateTemperatureTest> set)
        : Repository<SteadyStateTemperatureTest>(dbCtx, set);
}