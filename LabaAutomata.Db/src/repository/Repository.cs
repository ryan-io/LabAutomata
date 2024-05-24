using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.Db.repository;

/// <summary>
/// Represents a generic repository for managing entities in the database.
/// </summary>
/// <typeparam name="T">The type of entity.</typeparam>
public abstract class Repository<T> : IRepository<T> where T : LabModel {
    private readonly DbSet<T> _set;
    private readonly ILabPostgreSqlDbContext _dbCtx;

    /// <summary>
    /// Initializes a new instance of the <see cref="Repository{T}"/> class.
    /// </summary>
    /// <param name="dbCtx">The database context.</param>
    /// <param name="set">The DbSet for the entity type.</param>
    public Repository (ILabPostgreSqlDbContext dbCtx, DbSet<T> set) {
        _dbCtx = dbCtx;
        _set = set;
    }

    /// <summary>
    /// Creates a new entity in the database.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. Returns true if the entity was created successfully, false otherwise.</returns>
    public async Task<bool> Create (T entity, CancellationToken ct = default) {
        var entry = await _set.AddAsync(entity, ct);
        var saveSuccess = await _dbCtx.PostgreSqlDb.SaveChangesAsync(ct) > 0;
        return entry.State == EntityState.Unchanged && saveSuccess;
    }

    /// <summary>
    /// Retrieves an entity from the database by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to retrieve.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The retrieved entity, or null if not found.</returns>
    public async Task<T?> Get (int id, CancellationToken ct = default) {
        return await _set.FirstOrDefaultAsync(t => t.Id == id, cancellationToken: ct);
    }

    /// <summary>
    /// Retrieves all entities.
    /// </summary>
    /// <param name="ct">The cancellation token (optional).</param>
    /// <returns>A task representing the asynchronous operation. The task result is a collection of all retrieved entities.</returns>
    public async Task<List<T>> GetAll(CancellationToken ct = default)
    {
       return await _set.ToListAsync(ct);
    }

    /// <summary>
    /// Updates or inserts an entity in the database.
    /// </summary>
    /// <param name="id">The ID of the entity to update or insert.</param>
    /// <param name="entity">The entity to upsert.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. Returns true if the entity was updated or inserted successfully, false otherwise.</returns>
    public async Task<bool> Upsert (int id, T entity, CancellationToken ct = default) {
        var e = await _set.FirstOrDefaultAsync(e => id == e.Id, cancellationToken: ct);

        if (e != null) {
            _dbCtx.PostgreSqlDb.Entry(e).CurrentValues.SetValues(entity);
        }
        else {
            await Create(entity, ct);
        }

        return await _dbCtx.PostgreSqlDb.SaveChangesAsync(ct) > 0;
    }

    /// <summary>
    /// Deletes an entity from the database.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. Returns true if the entity was deleted successfully, false otherwise.</returns>
    public async Task<bool> Delete (int id, CancellationToken ct = default) {
        var entity = await _set.FirstOrDefaultAsync(e => id == e.Id, cancellationToken: ct);

        if (entity == null) {
            return false;
        }

        _dbCtx.PostgreSqlDb.Attach(entity);
        _set.Remove(entity);
        return await _dbCtx.PostgreSqlDb.SaveChangesAsync(ct) > 0;
    }
}