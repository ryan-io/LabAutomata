using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.service;
using Microsoft.AspNetCore.Mvc;

namespace LabAutomata.WebApi.controllers;

public class Dht22DataController : BaseController {
	[HttpPost("add")]
	public async Task<IActionResult> AddDht22Data (
		Dht22DataNewRequest request,
		CancellationToken token) {
		var addResult = await _service.AddData(request, token);

		if (addResult.IsError) {
			return ProblemInController(addResult.Errors);
		}

		return addResult.Match(
			_ => CreatedAtAction(nameof(AddDht22Data), addResult.Value),
			ProblemInController);
	}

	public Dht22DataController (IDht22DataService service) {
		_service = service;
	}

	private readonly IDht22DataService _service;
}