using LabAutomata.Db.factory;
using LabAutomata.Db.models;
using LabAutomata.Db.service;
using Microsoft.AspNetCore.Mvc;

namespace LabAutomata.WebApi.controllers {
    public class SsTempTestController (ISsTemperatureService service) : BaseController {
        // post: api/sstemptest/create
        [HttpPost("create")]
        public async Task<IActionResult> CreateSsTempTest (CancellationToken ct = default) {
            // factory call to get new model
            var unionCreateModel = SsTempTestFactory.Create(12345);

            // check if model creation had any errors
            if (unionCreateModel.IsError)
                return ProblemInController(unionCreateModel.Errors);

            // invoke service to save to db
            var unionSaveToService = await service.CreateSsTempTest(unionCreateModel.Value, ct);

            // optional mapping

            // this is expensive to do but versatile
            // location: /api/SsTempTest/{unionCreateModel.Value.Id}
            return unionSaveToService.Match(
                i => CreatedAtAction(nameof(CreateSsTempTest),
                                                   new { id = unionCreateModel.Value.Id },
                                                   unionCreateModel),
                ProblemInController);
        }

        [HttpGet("get/{id:int}")]
        public async Task<IActionResult> GetSsTempTest (int id, CancellationToken ct = default) {
            // query service to get the test
            var unionGetFromService = await service.GetSsTempTest(id, ct);

            // optional mapping:
            //      would be used to map the value from unionGetFromService.Value to a response
            //      this mapped response would be passed into the Match invocation instead of unionGetFromService.Value

            return unionGetFromService.Match(_ => Ok(unionGetFromService.Value), ProblemInController);
        }

        [HttpPut("upsert/ {id:int}")]
        public async Task<IActionResult> UpsertSsTempTest (int id, SteadyStateTemperatureTest test, CancellationToken ct = default) {
            var unionCreateClone = SsTempTestFactory.CloneWithId(id, test);

            if (unionCreateClone.IsError)
                return ProblemInController(unionCreateClone.Errors);

            var unionUpsertToService = await service.UpsertSsTempTest(id, unionCreateClone.Value, ct);

            return unionUpsertToService.Match(
                _ => Ok(unionUpsertToService.Value),
                ProblemInController);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteSsTempTest (int id, CancellationToken ct = default) {
            var unionTransferObjCreation = SsTempTestFactory.CreateForDeletion(id);

            if (unionTransferObjCreation.IsError)
                return ProblemInController(unionTransferObjCreation.Errors);

            var unionDeleteFromService = await service.DeleteSsTempTest(unionTransferObjCreation.Value, ct);

            return unionDeleteFromService.Match(_ => NoContent(), ProblemInController);
        }
    }
}