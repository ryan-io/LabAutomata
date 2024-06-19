using LabAutomata.DataAccess.factory;
using LabAutomata.DataAccess.service;
using LabAutomata.DataAccess.validation;
using LabAutomata.Dto.request;
using Microsoft.AspNetCore.Mvc;

namespace LabAutomata.WebApi.controllers
{
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


			// this is expensive to do but versatile
			// location: /api/SsTempTest/{unionCreateModel.Value.Id}
			return unionSaveToService.Match(
				i => CreatedAtAction(nameof(CreateWorkstation),
												   new { id = unionCreateModel.Value },
												   unionCreateModel.Value),
				ProblemInController);
		}


		// GET: api/workstation/id
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetSsTempTest ([FromRoute] int id, CancellationToken ct = default) {
			// query service to get the test
			var unionGetFromService = await _service.Get(id, ct);

			// optional mapping:
			//      would be used to map the value from unionGetFromService.Value to a response
			//      this mapped response would be passed into the Match invocation instead of unionGetFromService.Value

			return unionGetFromService.Match(_ => Ok(unionGetFromService.Value), ProblemInController);
		}

		// PUT: api/workstation/id
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpsertSsTempTest ([FromRoute] int id, WorkstationRequest request, CancellationToken ct = default) {
			//var factory = new SsTempTestFactory();
			//var unionCreateClone = factory.CloneWithId(id, request);

			//if (unionCreateClone.IsError)
			//	return ProblemInController(unionCreateClone.Errors);

			//var unionUpsertToService = await service.Upsert(id, unionCreateClone.Value, ct);

			//return unionUpsertToService.Match(
			//	_ => Ok(unionCreateClone.Value),
			//	ProblemInController);

			return Ok(request);
		}

		// DELETE: api/workstation/id
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteSsTempTest ([FromRoute] int id, CancellationToken ct = default) {
			var factory = new
				SsTempTestFactory();
			var unionTransferObjCreation = factory.CreateForDeletion(id);

			if (unionTransferObjCreation.IsError)
				return ProblemInController(unionTransferObjCreation.Errors);

			var unionDeleteFromService = await _service.Delete(id, ct);

			return unionDeleteFromService.Match(_ => NoContent(), ProblemInController);
		}

		public WorkstationController (
			WorkstationService service,
			WorkstationValidator validator) {
			_service = service;
			_validator = validator;
		}

		private readonly WorkstationValidator _validator;

		private readonly WorkstationService _service;
	}
}