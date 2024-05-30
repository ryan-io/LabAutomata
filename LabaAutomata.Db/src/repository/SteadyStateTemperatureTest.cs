using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.Db.repository;

/// <summary>
/// Represents a repository for managing SteadyStateTemperatureTest entities in the database.
/// </summary>
public class SteadyStateTemperatureTest (ILabPostgreSqlDbContext dbCtx)
    : Repository<Test>(dbCtx, dbCtx.Test) {
    public override async Task<List<Test>> GetAll (CancellationToken ct = default) {
        return await DbCtx.Test.Include(t => t.Workstations)
            .ToListAsync(cancellationToken: ct);
    }
}