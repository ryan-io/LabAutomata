//using ErrorOr;

//namespace LabAutomata.DataAccess.service;

//public interface IService<TRequest, TResponse> {
//	/// <summary>
//	/// Creates a new Workstation entity.
//	/// </summary>
//	/// <param name="request">The request object containing the data for creating the Workstation.</param>
//	/// <param name="ct">The cancellation token.</param>
//	/// <returns>An <see cref="ErrorOr{T}"/> object containing the result of the operation.</returns>
//	Task<ErrorOr<CreatedResponse<TResponse>>> Create (TRequest request, CancellationToken ct = default);

//	/// <summary>
//	/// Gets an entity by its ID.
//	/// </summary>
//	/// <param name="id">The ID of the entity to get.</param>
//	/// <param name="ct">The cancellation token.</param>
//	/// <returns>An <see cref="ErrorOr{T}"/> indicating the result of the operation.</returns>
//	Task<ErrorOr<TResponse>> Get (int id, CancellationToken ct = default);

//	/// <summary>
//	/// Gets all entities.
//	/// </summary>
//	/// <param name="ct">The cancellation token.</param>
//	/// <returns>An <see cref="ErrorOr{IList{TResponse}}"/> indicating the result of the operation.</returns>
//	Task<ErrorOr<IList<TResponse>>> GetAll (CancellationToken ct = default);

//	/// <summary>
//	/// Updates or inserts a dtoEntity.
//	/// </summary>
//	/// <param name="id">The ID of the dtoEntity to update or insert.</param>
//	/// <param name="request">The request to map</param>
//	/// <param name="ct">The cancellation token.</param>
//	/// <returns>An <see cref="ErrorOr{Updated}"/> indicating the result of the operation.</returns>
//	Task<ErrorOr<Updated>> Upsert (int id, TRequest request, CancellationToken ct = default);

//	/// <summary>
//	/// Deletes an entity by its ID.
//	/// </summary>
//	/// <param name="id">The ID of the entity to delete.</param>
//	/// <param name="ct">The cancellation token.</param>
//	/// <returns>An <see cref="ErrorOr{Deleted}"/> indicating the result of the operation.</returns>
//	Task<ErrorOr<Deleted>> Delete (int id, CancellationToken ct = default);
//}
