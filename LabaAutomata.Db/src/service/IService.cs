using ErrorOr;
using LabAutomata.Db.models;

namespace LabAutomata.Db.service;

public interface IService<T> where T : LabModel {
    /// <summary>
    /// Creates a new entity.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>An <see cref="ErrorOr{Created}"/> indicating the result of the operation.</returns>
    Task<ErrorOr<Created>> Create (T entity, CancellationToken ct = default);

    /// <summary>
    /// Gets an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to get.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>An <see cref="ErrorOr{T}"/> indicating the result of the operation.</returns>
    Task<ErrorOr<T>> Get (int id, CancellationToken ct = default);

    /// <summary>
    /// Updates or inserts an entity.
    /// </summary>
    /// <param name="id">The ID of the entity to update or insert.</param>
    /// <param name="entity">The entity to update or insert.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>An <see cref="ErrorOr{Updated}"/> indicating the result of the operation.</returns>
    Task<ErrorOr<Updated>> Upsert (int id, T entity, CancellationToken ct = default);

    /// <summary>
    /// Deletes an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>An <see cref="ErrorOr{Deleted}"/> indicating the result of the operation.</returns>
    Task<ErrorOr<Deleted>> Delete (int id, CancellationToken ct = default);
}