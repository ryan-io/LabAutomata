using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.Db.repository {
    /// <summary>
    /// Represents a repository for managing SteadyStateTemperatureTest entities in the database.
    /// </summary>
    public class SsTemperatureRepository : IRepository<SteadyStateTemperatureTest> {
        private readonly LabPostgreSqlDbContext _dbCtx;

        /// <summary>
        /// Initializes a new instance of the <see cref="SsTemperatureRepository"/> class.
        /// </summary>
        /// <param name="dbCtx">The database context.</param>
        public SsTemperatureRepository (LabPostgreSqlDbContext dbCtx) { _dbCtx = dbCtx; }

        /// <summary>
        /// Creates a new SteadyStateTemperatureTest entity in the database.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<bool> Create (SteadyStateTemperatureTest entity, CancellationToken ct = default) {
            var entry = await _dbCtx.SsTempTests.AddAsync(entity, ct);
            var saveSuccess = await _dbCtx.SaveChangesAsync(ct) > 0;
            return entry.State == EntityState.Unchanged && saveSuccess;
        }

        /// <summary>
        /// Retrieves a SteadyStateTemperatureTest entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The retrieved entity, or null if not found.</returns>
        public async Task<SteadyStateTemperatureTest?> Get (int id, CancellationToken ct = default) {
            return await _dbCtx.SsTempTests.FirstOrDefaultAsync(t => t.Id == id, cancellationToken: ct);
        }

        /// <summary>
        /// Updates or inserts a SteadyStateTemperatureTest entity in the database.
        /// </summary>
        /// <param name="id">Id of the entity to make the updates to.</param>
        /// <param name="entity">The entity to upsert.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<bool> Upsert (int id, SteadyStateTemperatureTest entity, CancellationToken ct = default) {
            var e = await _dbCtx.SsTempTests.FirstOrDefaultAsync(e => id == e.Id, cancellationToken: ct);

            if (e != null) _dbCtx.Entry(e).CurrentValues.SetValues(entity);
            else await Create(entity, ct);

            return await _dbCtx.SaveChangesAsync(ct) > 0;
            //if (result > 0) return new Updated();
            //return new Error(); // TODO: more precise error?
        }

        /// <summary>
        /// Deletes a SteadyStateTemperatureTest entity from the database.
        /// </summary>
        /// <param name="instanceId">The entity's instance id to delete. Attaches to the correct DbSet then invokes Remove.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<bool> Delete (int instanceId, CancellationToken ct = default) {
            var entity =
                await _dbCtx.SsTempTests.FirstOrDefaultAsync(e => instanceId == e.InstanceId, cancellationToken: ct);

            if (entity == null)
                return false;

            _dbCtx.Attach(entity);
            _dbCtx.SsTempTests.Remove(entity);
            return await _dbCtx.SaveChangesAsync(ct) > 0;
        }
    }
}