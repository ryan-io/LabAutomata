using ErrorOr;
using LabAutomata.DataAccess.common;
using LabAutomata.Db.common;

namespace LabAutomata.DataAccess.service {

	/// <summary>
	/// Represents a service class that provides CRUD operations for a specific entity type.
	/// </summary>
	public abstract class Service<TModel, TRequest, TResponse> : IService<TRequest, TResponse> {

		/// <summary>
		/// Gets an entity by its ID.
		/// </summary>
		/// <param name="id">The ID of the entity to get.</param>
		/// <param name="ct">The cancellation token.</param>
		/// <returns>An <see cref="ErrorOr{T}"/> indicating the result of the operation.</returns>
		public async Task<ErrorOr<TResponse>> Get (int id, CancellationToken ct = default) {
			var entity = await Repository.Get(id, ct);

			if (entity == null) {
				return Errors.Db.CouldNotGet($"Entity.IdCouldNotBeFound - {ModelName}", "Could not find an entity with the provided id.");
			}

			var response = Mapper.ToResponse(entity);
			return response;
		}

		/// <summary>
		/// Gets all entities.
		/// </summary>
		/// <param name="ct">The cancellation token.</param>
		/// <returns>An <see cref="ErrorOr{IList{TResponse}}"/> indicating the result of the operation.</returns>
		public async Task<ErrorOr<IList<TResponse>>> GetAll (CancellationToken ct = default) {
			var entities = await Repository.GetAll(ct);

			if (entities.Count < 1)
				return Errors.Db.CouldNotGetAll($"Entity.GetAllWasEmpty - {ModelName}",
					"The returned list for 'get all entities' was empty.");

			var output = new List<TResponse> { Capacity = entities.Count };

			foreach (var entity in entities) {
				output.Add(Mapper.ToResponse(entity));
			}

			return output;
		}


		/// <summary>
		/// Updates or inserts an dtoEntity.
		/// </summary>
		/// <param name="id">The ID of the dtoEntity to update or insert.</param>
		/// <param name="request">The request to map</param>
		/// <param name="ct">The cancellation token.</param>
		/// <returns>An <see cref="ErrorOr{Updated}"/> indicating the result of the operation.</returns>
		public async Task<ErrorOr<Updated>> Upsert (int id, TRequest request, CancellationToken ct = default) {
			var entity = Mapper.ToModel(request);

			var result = await Repository.Upsert(id, entity, ct);

			if (result)
				return new Updated();
			return Errors.Db.CouldNotUpsert($"Entity.CouldNotUpsert - {ModelName}", "Could not upsert the dtoEntity.");
		}

		/// <summary>
		/// Deletes an entity by its ID.
		/// </summary>
		/// <param name="id">The ID of the entity to delete.</param>
		/// <param name="ct">The cancellation token.</param>
		/// <returns>An <see cref="ErrorOr{Deleted}"/> indicating the result of the operation.</returns>
		public async Task<ErrorOr<Deleted>> Delete (int id, CancellationToken ct = default) {
			var result = await Repository.Delete(id, ct);

			if (result) {
				return new Deleted();
			}
			return Errors.Db.CouldNotDelete($"Entity.CouldNotDelete - {ModelName}", "Could not delete the entity.");
		}

		protected readonly IMapper<TModel, TRequest, TResponse> Mapper;


		private string ModelName => typeof(TModel).Name;

		private readonly PostgreSqlDbContext _dbCtx;
	}
}