using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.service;
using Microsoft.AspNetCore.Mvc;

namespace LabAutomata.WebApi.controllers {
	public class LocationController : BaseController {
		[HttpPost("new")]
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

		public LocationController (ILocationService service) {
			_service = service;
		}

		private readonly ILocationService _service;
	}
}
