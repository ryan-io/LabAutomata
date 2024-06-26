﻿using LabAutomata.Db.models;

namespace LabAutomata.Db.repository;

/// <summary>
/// Represents a generic repository interface for CRUD operations on entities of type T.
/// </summary>
/// <typeparam name="T">The type of entity.</typeparam>
public interface IRepository<T> : IRepositoryCreate<T>,
								  IRepositoryGet<T>,
								  IRepositoryUpsert<T>,
								  IRepositoryDelete<T> where T : LabModel {
}

public interface IRepositoryCreate<T> where T : LabModel {

	/// <summary>
	/// Creates a new entity.
	/// </summary>
	/// <param name="entity">The entity to create.</param>
	/// <param name="ct">The cancellation token (optional).</param>
	/// <returns>A task representing the asynchronous operation. The task result is true if the entity was created successfully, false otherwise.</returns>
	Task<bool> Create (T entity, CancellationToken ct = default);
}

public interface IRepositoryGet<T> where T : LabModel {

	/// <summary>
	/// Retrieves an entity by its ID.
	/// </summary>
	/// <param name="id">The ID of the entity to retrieve.</param>
	/// <param name="ct">The cancellation token (optional).</param>
	/// <returns>A task representing the asynchronous operation. The task result is the retrieved entity, or null if the entity was not found.</returns>
	Task<T?> Get (int id, CancellationToken ct = default);

	/// <summary>
	/// Retrieves all entities.
	/// </summary>
	/// <param name="ct">The cancellation token (optional).</param>
	/// <returns>A task representing the asynchronous operation. The task result is a collection of all retrieved entities.</returns>
	Task<List<T>> GetAll (CancellationToken ct = default);
}

public interface IRepositoryUpsert<T> where T : LabModel {

	/// <summary>
	/// Upserts an entity.
	/// </summary>
	/// <param name="id">Id of the entity to make the updates to.</param>
	/// <param name="entity">The entity to upsert.</param>
	/// <param name="ct">The cancellation token (optional).</param>
	/// <returns>A task representing the asynchronous operation.</returns>
	Task<bool> Upsert (int id, T entity, CancellationToken ct = default);

	/// <summary>
	/// Upserts an entity. This overload requires the entity to have an ID assigned
	/// </summary>
	/// <param name="entity">The entity to upsert.</param>
	/// <param name="ct">The cancellation token (optional).</param>
	/// <returns>A task representing the asynchronous operation.</returns>
	Task<bool> Upsert (T entity, CancellationToken ct = default);
}

public interface IRepositoryDelete<T> where T : LabModel {

	/// <summary>
	/// Deletes an entity.
	/// </summary>
	/// <param name="instanceId">Instance id of the test to delete. Attaches to the correct DbSet then invokes Remove.</param>
	/// <param name="ct">The cancellation token (optional).</param>
	/// <returns>A task representing the asynchronous operation.</returns>
	Task<bool> Delete (int instanceId, CancellationToken ct = default);
}