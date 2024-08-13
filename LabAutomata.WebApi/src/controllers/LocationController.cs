using ErrorOr;
using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.response;
using LabAutomata.DataAccess.service;
using Microsoft.AspNetCore.Mvc;

namespace LabAutomata.WebApi.controllers {
	public class LocationController : BaseController {
		/// <summary>
		/// 'ProblemInController' if any errors resulted
		/// 'CreatedAtAction' with the response if okay; else 'ProblemInController'
		/// </summary>
		[HttpPost("new")]
		[ProducesResponseType(typeof(ErrorOr<LocationResponse>), 200)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> CreateLocation (
			LocationNewRequest request,
			CancellationToken token) {
			var addResult = await _service.AddLocation(request, token);

			if (addResult.IsError) {
				return ProblemInController(addResult.Errors);
			}

			return addResult.Match(
				_ => CreatedAtAction(nameof(CreateLocation), addResult.Value),
				ProblemInController);
		}

		/// <summary>
		/// 'NoContent' if the request performed an update
		/// 'Ok' if the request performed a creation
		/// </summary>
		/// TODO: if applicable? implement 'ErrorOr' return
		[HttpPut("update")]
		public async Task<IActionResult> UpsertLocation (
			LocationRequest request,
			CancellationToken token) {
			var upsertResponse = await _service.UpsertLocation(request, token);

			if (upsertResponse.WasUpdated) {
				return NoContent(); // 204 - Success
			}

			// invoke 'CreateAtAction' if the upsert resulted in creation
			// if for some reason return 200, use 'return Ok()'
			return CreatedAtAction(nameof(UpsertLocation), upsertResponse);  // 201 - CREATED
		}

		public LocationController (ILocationService service) {
			_service = service;
		}

		private readonly ILocationService _service;
	}
}
