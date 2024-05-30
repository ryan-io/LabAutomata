using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.Db.repository {
    /// <summary>
    /// Represents a repository for managing Test entities in the database.
    /// </summary>
    public class TestRepository (ILabPostgreSqlDbContext dbCtx)
        : Repository<Test>(dbCtx, dbCtx.Test);

    /// <summary>
    /// Represents a repository for managing TestType entities in the database.
    /// </summary>
    public class TestTypeRepository (ILabPostgreSqlDbContext dbCtx)
        : Repository<TestType>(dbCtx, dbCtx.TestType);

    /// <summary>
    /// Represents a repository for managing Personnel entities in the database.
    /// </summary>
    public class PersonnelRepository (ILabPostgreSqlDbContext dbCtx)
        : Repository<Personnel>(dbCtx, dbCtx.Personnels);

    /// <summary>
    /// Represents a repository for managing Location entities in the database.
    /// </summary>
    public class LocationRepository (ILabPostgreSqlDbContext dbCtx)
        : Repository<Location>(dbCtx, dbCtx.Location);

    /// <summary>
    /// Represents a repository for managing Manufacturer entities in the database.
    /// </summary>
    public class ManufacturerRepository (ILabPostgreSqlDbContext dbCtx)
        : Repository<Manufacturer>(dbCtx, dbCtx.Manufacturers);

    /// <summary>
    /// Represents a repository for managing Work Request entities in the database.
    /// </summary>
    public class SeedDataRepository (ILabPostgreSqlDbContext dbCtx)
        : Repository<SeedJson>(dbCtx, dbCtx.SeedJson);

    /// <summary>
    /// Represents a repository for managing Work Request entities in the database.
    /// </summary>
    public class WorkRequestRepository (ILabPostgreSqlDbContext dbCtx)
        : Repository<WorkRequest>(dbCtx, dbCtx.WorkRequests) {
        public override async Task<List<WorkRequest>> GetAll (CancellationToken ct = default) {
            return await DbCtx.WorkRequests
                .Include(wr => wr.Tests)
                .ToListAsync(cancellationToken: ct);
        }
    }

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

    /// <summary>
    /// Represents a repository for managing Work Request entities in the database.
    /// </summary>
    public class WorkstationRepository (ILabPostgreSqlDbContext dbCtx)
        : Repository<Workstation>(dbCtx, dbCtx.Workstations) {
        public override async Task<List<Workstation>> GetAll (CancellationToken ct = default) {
            return await DbCtx.Workstations
                .Include(ws => ws.Tests)
                .ToListAsync(cancellationToken: ct);
        }
    }
}