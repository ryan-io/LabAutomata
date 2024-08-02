//using LabAutomata.DataAccess.mapper;
//using LabAutomata.Db.models;
//using LabAutomata.Db.repository;
//using LabAutomata.Dto.request;
//using LabAutomata.Dto.response;

//namespace LabAutomata.DataAccess.service;

///// <summary>
///// Service class for managing Workstation entities.
///// </summary>
//public class WorkstationService : Service<Workstation, WorkstationRequest, WorkstationResponse> {
//	/// <summary>
//	/// Initializes a new instance of the <see cref="WorkstationService"/> class.
//	/// </summary>
//	/// <param name="repository">The repository for accessing Workstation entities.</param>
//	/// <param name="mapper">Model mapper</param>
//	public WorkstationService (
//		IRepository<Workstation> repository,
//		IMapper<Workstation, WorkstationRequest, WorkstationResponse> mapper
//		) : base(repository, mapper) { }

//}