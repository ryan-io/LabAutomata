using LabAutomata.DataAccess.service;
using LabAutomata.DataAccess.validation;
using LabAutomata.Dto.request;
using LabAutomata.Dto.response;
using Microsoft.AspNetCore.Mvc;

namespace LabAutomata.WebApi.controllers {
	public class WorkstationController : BaseController {
		// POST: api/workstation/
		[HttpPost()]
		public async Task<IActionResult> CreateWorkstation (WorkstationRequest request, CancellationToken ct = default) {
			// validate all properties within the request
			// ensure the request is in a valid state before querying the user service to create a db entity model
			var unionCreateModel = _validator.ValidateRequest(request);

			// check if model creation had any errors
			if (unionCreateModel.IsError)
				return ProblemInController(unionCreateModel.Errors);

			// invoke service to save to db
			var unionSaveToService = await _service.Create(unionCreateModel.Value, ct);
			var unionSaveValidated = _validator.ValidateResponse(unionSaveToService.Value.Response);

			if (unionSaveValidated.IsError)
				return ProblemInController(unionSaveValidated.Errors);

			// this is expensive to do but versatile
			// location: /api/SsTempTest/{unionCreateModel.Value.Id}
			return unionSaveValidated.Match(
				i => CreatedAtAction(nameof(CreateWorkstation),
												   new { id = unionSaveValidated.Value },
												   unionSaveValidated.Value),
				ProblemInController);
		}


		// GET: api/workstation/id
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetWorkstation ([FromRoute] int id, CancellationToken ct = default) {
			// query service to get the test
			var unionGetFromService = await _service.Get(id, ct);
			var unionGetValidated = _validator.ValidateResponse(unionGetFromService.Value);
			// optional mapping:
			//      would be used to map the value from unionGetFromService.Value to a response
			//      this mapped response would be passed into the Match invocation instead of unionGetFromService.Value

			return unionGetValidated.Match(_ => Ok(unionGetValidated.Value), ProblemInController);
		}

		// GET: api/workstation/
		[HttpGet]
		public async Task<IActionResult> GetWorkstations (CancellationToken ct = default) {
			// query service to get the test
			var unionGetFromService = await _service.GetAll(ct);


			// optional mapping:
			//      would be used to map the value from unionGetFromService.Value to a response
			//      this mapped response would be passed into the Match invocation instead of unionGetFromService.Value

			return unionGetFromService.Match(_ => Ok(unionGetFromService.Value), ProblemInController);
		}

		// PUT: api/workstation/id
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpsertWorkstation ([FromRoute] int id, [FromBody] WorkstationRequest request, CancellationToken ct = default) {
			var unionCreateClone = _validator.ValidateRequest(request);

			if (unionCreateClone.IsError)
				return ProblemInController(unionCreateClone.Errors);

			var unionUpsertToService = await _service.Upsert(id, unionCreateClone.Value, ct);

			return unionUpsertToService.Match(
				_ => Ok(unionCreateClone.Value),
				ProblemInController);
		}

		// DELETE: api/workstation/id
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteWorkstation ([FromRoute] int id, CancellationToken ct = default) {
			var unionTransferObjCreation = await _service.Delete(id, ct);

			if (unionTransferObjCreation.IsError)
				return ProblemInController(unionTransferObjCreation.Errors);

			return unionTransferObjCreation.Match(_ => NoContent(), ProblemInController);
		}

		public WorkstationController (
			IService<WorkstationRequest, WorkstationResponse> service,
			WorkstationValidator validator) {
			_service = service;
			_validator = validator;
		}

		private readonly WorkstationValidator _validator;

		private readonly IService<WorkstationRequest, WorkstationResponse> _service;
	}
}