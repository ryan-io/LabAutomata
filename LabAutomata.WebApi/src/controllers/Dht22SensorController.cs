using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.service;
using Microsoft.AspNetCore.Mvc;

namespace LabAutomata.WebApi.controllers;

public class Dht22SensorController : BaseController {
	/// <summary>
	/// POST: api/dht22sensor/
	/// Queries an add sensor request and passes it along to a Dht22Sensor service
	/// if result.IsError -> returns ProblemInController(result.Errors)
	/// Invokes ErrorOr.Match -> success: CreatedAtAction; failure: ProblemInController
	/// </summary>
	[HttpPost("new")]
	public async Task<IActionResult> CreateDht22Sensor (
		Dht22SensorNewRequest request,
		CancellationToken token) {
		var addResult = await _service.AddSensor(request, token);

		if (addResult.IsError) {
			return ProblemInController(addResult.Errors);
		}

		return addResult.Match(
			_ => CreatedAtAction(nameof(CreateDht22Sensor), addResult.Value),
			ProblemInController);
	}

	[HttpGet("{id:int}")]
	public async Task<IActionResult> GetDht22Sensor ([FromRoute] int id, CancellationToken ct) {
		var request = new Dht22SensorGetRequest(id);
		var getResult = await _service.GetSensor(request, ct);

		if (getResult.IsError) {
			return ProblemInController(getResult.Errors);
		}

		return getResult.Match(
			_ => CreatedAtAction(nameof(GetDht22Sensor), getResult.Value),
			ProblemInController);
	}

	public Dht22SensorController (IDht22SensorService service) {
		_service = service;
	}

	private readonly IDht22SensorService _service;
}