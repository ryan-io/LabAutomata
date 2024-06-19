using ErrorOr;
using LabAutomata.DataAccess.common;
using LabAutomata.DataAccess.mapper;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.DataAccess.service {
	/// <summary>
	/// Represents a service class that provides CRUD operations for a specific entity type.
	/// </summary>
	/// <typeparam name="TModel">The type of the entity.</typeparam>
	/// <typeparam name="TRequest">Request DTO</typeparam>
	/// <typeparam name="TResponse">Response DTO</typeparam>
	public abstract class Service<TModel, TRequest, TResponse> : IService<TRequest, TResponse> where TModel : LabModel {
		protected readonly IRepository<TModel> Repository;
		protected readonly IMapper<TModel, TRequest, TResponse> Mapper;

		/// <summary>
		/// Base constructor
		/// </summary>
		/// <param name="repository">The repository used for data access.</param>
		/// <param name="mapper">A mapper instance for transforming models to dtos and dtos to models</param>
		internal Service (
			IRepository<TModel> repository,
			IMapper<TModel, TRequest, TResponse> mapper) {
			Repository = repository;
			Mapper = mapper;
		}

		/// <summary>
		/// Creates a new Workstation entity.
		/// </summary>
		/// <param name="request">The request object containing the data for creating the Workstation.</param>
		/// <param name="ct">The cancellation token.</param>
		/// <returns>An <see cref="ErrorOr{T}"/> object containing the result of the operation.</returns>
		public async Task<ErrorOr<CreatedResponse<TResponse>>> Create (TRequest request, CancellationToken ct = default) {
			var model = Mapper.ToModel(request);
			var result = await Repository.Create(model, ct);

			if (result) {
				var response = Mapper.ToResponse(model);
				return new CreatedResponse<TResponse>() { IsError = result, Response = response };
			}

			return Errors.Db.CouldNotCreate("Entity.EntryReturned0", "Entry returned 0; this needs to be debugged.");
		}

		/// <summary>
		/// Gets an entity by its ID.
		/// </summary>
		/// <param name="id">The ID of the entity to get.</param>
		/// <param name="ct">The cancellation token.</param>
		/// <returns>An <see cref="ErrorOr{T}"/> indicating the result of the operation.</returns>
		public async Task<ErrorOr<TResponse>> Get (int id, CancellationToken ct = default) {
			var entity = await Repository.Get(id, ct);

			if (entity == null) {
				return Errors.Db.CouldNotGet("Entity.IdCouldNotBeFound", "Could not find an entity with the provided id.");
			}

			var response = Mapper.ToResponse(entity);
			return response;
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
			return Errors.Db.CouldNotUpsert("Entity.CouldNotUpsert" + typeof(TModel).Name, "Could not upsert the dtoEntity.");
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
			return Errors.Db.CouldNotDelete("Entity.CouldNotDelete", "Could not delete the entity.");
		}
	}

	public class CreatedResponse<TResponse> {
		public TResponse Response { get; init; }
		public bool IsError { get; init; }
	}
}