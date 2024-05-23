using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.Db.repository {
    /// <summary>
    /// Represents a repository for managing Work Request entities in the database.
    /// </summary>
    public class WorkRequestRepository (ILabPostgreSqlDbContext dbCtx)
        : Repository<WorkRequest>(dbCtx, dbCtx.WorkRequests);

    /// <summary>
    /// Represents a repository for managing SteadyStateTemperatureTest entities in the database.
    /// </summary>
    public class SsTemperatureRepository (ILabPostgreSqlDbContext dbCtx)
        : Repository<SteadyStateTemperatureTest>(dbCtx, dbCtx.SsTempTests);
}