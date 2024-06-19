//using Microsoft.AspNetCore.Mvc;

//namespace LabAutomata.WebApi.controllers {
//	public class TestController (TestService service) : BaseController {
//		// post: api/sstemptest/create/instanceId
//		[HttpPost("create/{instanceId:int}")]
//		public async Task<IActionResult> CreateSsTempTest ([FromRoute] int instanceId, CancellationToken ct = default) {
//			// factory call to get new model
//			var factory = new SsTempTestFactory();
//			var unionCreateModel = factory.GetNew(instanceId, TestTypeFactory.PowerTemperatureCycling());

//			// check if model creation had any errors
//			if (unionCreateModel.IsError)
//				return ProblemInController(unionCreateModel.Errors);

//			// invoke service to save to db
//			var unionSaveToService = await service.GetNew(unionCreateModel.Value, ct);

//			// optional mapping

//			// this is expensive to do but versatile
//			// location: /api/SsTempTest/{unionCreateModel.Value.Id}
//			return unionSaveToService.Match(
//				i => CreatedAtAction(nameof(CreateSsTempTest),
//												   new { id = unionCreateModel.Value.Id },
//												   unionCreateModel),
//				ProblemInController);
//		}

//		[HttpGet("get/{id:int}")]
//		public async Task<IActionResult> GetSsTempTest (int id, CancellationToken ct = default) {
//			// query service to get the test
//			var unionGetFromService = await service.Get(id, ct);

//			// optional mapping:
//			//      would be used to map the value from unionGetFromService.Value to a response
//			//      this mapped response would be passed into the Match invocation instead of unionGetFromService.Value

//			return unionGetFromService.Match(_ => Ok(unionGetFromService.Value), ProblemInController);
//		}

//		[HttpPut("upsert/{id:int}")]
//		public async Task<IActionResult> UpsertSsTempTest ([FromRoute] int id, Test update, CancellationToken ct = default) {
//			var factory = new SsTempTestFactory();
//			var unionCreateClone = factory.CloneWithId(id, update);

//			if (unionCreateClone.IsError)
//				return ProblemInController(unionCreateClone.Errors);

//			var unionUpsertToService = await service.Upsert(id, unionCreateClone.Value, ct);

//			return unionUpsertToService.Match(
//				_ => Ok(unionCreateClone.Value),
//				ProblemInController);
//		}

//		[HttpDelete("delete/{id:int}")]
//		public async Task<IActionResult> DeleteSsTempTest ([FromRoute] int id, CancellationToken ct = default) {
//			var factory = new SsTempTestFactory();
//			var unionTransferObjCreation = factory.CreateForDeletion(id);

//			if (unionTransferObjCreation.IsError)
//				return ProblemInController(unionTransferObjCreation.Errors);

//			var unionDeleteFromService = await service.Delete(id, ct);

//			return unionDeleteFromService.Match(_ => NoContent(), ProblemInController);
//		}
//	}
//}