using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.Db.repository;


/// <summary>
/// Represents a generic repository for managing entities in the database.
/// </summary>
/// <typeparam name="T">The type of entity.</typeparam>
public abstract class Repository<T> : IRepository<T> where T : LabModel {
    protected readonly DbSet<T> Set;
    protected readonly ILabPostgreSqlDbContext DbCtx;

    /// <summary>
    /// Initializes a new instance of the <see cref="Repository{T}"/> class.
    /// </summary>
    /// <param name="dbCtx">The database context.</param>
    /// <param name="set">The DbSet for the entity type.</param>
    public Repository (ILabPostgreSqlDbContext dbCtx, DbSet<T> set) {
        DbCtx = dbCtx;
        Set = set;
    }

    /// <summary>
    /// Creates a new entity in the database.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. Returns true if the entity was created successfully, false otherwise.</returns>
    public virtual async Task<bool> Create (T entity, CancellationToken ct = default) {
        var entry = await Set.AddAsync(entity, ct);
        var saveSuccess = await DbCtx.PostgreSqlDb.SaveChangesAsync(ct) > 0;

        return entry.State == EntityState.Unchanged && saveSuccess;
    }

    /// <summary>
    /// Retrieves an entity from the database by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to retrieve.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The retrieved entity, or null if not found.</returns>
    public virtual async Task<T?> Get (int id, CancellationToken ct = default) {
        return await Set.FirstOrDefaultAsync(t => t.Id == id, cancellationToken: ct);
    }

    /// <summary>
    /// Retrieves all entities.
    /// </summary>
    /// <param name="ct">The cancellation token (optional).</param>
    /// <returns>A task representing the asynchronous operation. The task result is a collection of all retrieved entities.</returns>
    public virtual async Task<List<T>> GetAll (CancellationToken ct = default) {
        return await Set.ToListAsync(ct);
    }

    /// <summary>
    /// Updates or inserts an entity in the database.
    /// </summary>
    /// <param name="id">The ID of the entity to update or insert.</param>
    /// <param name="entity">The entity to upsert.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. Returns true if the entity was updated or inserted successfully, false otherwise.</returns>
    public virtual async Task<bool> Upsert (int id, T entity, CancellationToken ct = default) {
        var e = await Set.FirstOrDefaultAsync(e => id == e.Id, cancellationToken: ct);

        if (e != null) {
            DbCtx.PostgreSqlDb.Entry(e).CurrentValues.SetValues(entity);
        }
        else {
            await Create(entity, ct);
        }

        return await DbCtx.PostgreSqlDb.SaveChangesAsync(ct) > 0;
    }

    /// <summary>
    /// Updates or inserts an entity in the database. This overload assumes an Id is assigned to the entity.
    /// It will check against the database for this Id.
    /// </summary>
    /// <param name="entity">The entity to upsert.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. Returns true if the entity was updated or inserted successfully, false otherwise.</returns>
    public async Task<bool> Upsert (T entity, CancellationToken ct = default) {
        ArgumentOutOfRangeException.ThrowIfLessThan(entity.Id, 0, NoIdAssigned);
        return await Upsert(entity.Id, entity, ct);
    }

    /// <summary>
    /// Deletes an entity from the database.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. Returns true if the entity was deleted successfully, false otherwise.</returns>
    public virtual async Task<bool> Delete (int id, CancellationToken ct = default) {
        var entity = await Set.FirstOrDefaultAsync(e => id == e.Id, cancellationToken: ct);

        if (entity == null) {
            return false;
        }

        DbCtx.PostgreSqlDb.Attach(entity);
        Set.Remove(entity);
        return await DbCtx.PostgreSqlDb.SaveChangesAsync(ct) > 0;
    }

    private const string NoIdAssigned = "An id must be assigned to use this overload.";
}