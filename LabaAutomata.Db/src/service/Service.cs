using ErrorOr;
using LabAutomata.Db.common;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.Db.service {
    /// <summary>
    /// Represents a service class that provides CRUD operations for a specific entity type.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public abstract class Service<T> : IService<T> where T : LabModel {
        private readonly IRepository<T> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{T}"/> class.
        /// </summary>
        /// <param name="repository">The repository used for data access.</param>
        public Service (IRepository<T> repository) {
            _repository = repository;
        }

        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>An <see cref="ErrorOr{Created}"/> indicating the result of the operation.</returns>
        public async Task<ErrorOr<Created>> Create (T entity, CancellationToken ct = default) {
            var result = await _repository.Create(entity, ct);

            if (result) {
                return new Created();
            }
            return Errors.Db.CouldNotCreate("Entity.EntryReturned0", "Entry returned 0; this needs to be debugged.");
        }

        /// <summary>
        /// Gets an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to get.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>An <see cref="ErrorOr{T}"/> indicating the result of the operation.</returns>
        public async Task<ErrorOr<T>> Get (int id, CancellationToken ct = default) {
            var entity = await _repository.Get(id, ct);

            if (entity == null) {
                return Errors.Db.CouldNotGet("Entity.IdCouldNotBeFound", "Could not find an entity with the provided id.");
            }
            return entity;
        }

        /// <summary>
        /// Updates or inserts an entity.
        /// </summary>
        /// <param name="id">The ID of the entity to update or insert.</param>
        /// <param name="entity">The entity to update or insert.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>An <see cref="ErrorOr{Updated}"/> indicating the result of the operation.</returns>
        public async Task<ErrorOr<Updated>> Upsert (int id, T entity, CancellationToken ct = default) {
            var result = await _repository.Upsert(id, entity, ct);

            if (result)
                return new Updated();
            return Errors.Db.CouldNotUpsert("Entity.CouldNotUpsert" + typeof(T).Name, "Could not upsert the entity.");
        }

        /// <summary>
        /// Deletes an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>An <see cref="ErrorOr{Deleted}"/> indicating the result of the operation.</returns>
        public async Task<ErrorOr<Deleted>> Delete (int id, CancellationToken ct = default) {
            var result = await _repository.Delete(id, ct);

            if (result) {
                return new Deleted();
            }
            return Errors.Db.CouldNotDelete("Entity.CouldNotDelete", "Could not delete the entity.");
        }
    }
}