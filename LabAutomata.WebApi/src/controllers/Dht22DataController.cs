using ErrorOr;
using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.response;
using LabAutomata.DataAccess.service;
using Microsoft.AspNetCore.Mvc;

namespace LabAutomata.WebApi.controllers;

public class Dht22DataController : BaseController {
	/// <summary>
	/// The request is expecting valid JSON due to the 'jsonb' constraint within PostgreSQL
	/// 'ProblemInController' will be invoked with an 'InvalidJsonError' if the
	///		jsonString is not valid
	/// </summary>
	[HttpPost("add")]
	[ProducesResponseType(typeof(ErrorOr<Dht22SensorResponse>), 200)]
	[ProducesResponseType(417)]
	public async Task<IActionResult> AddDht22Data (
		Dht22AddDataToSensorRequest request,
		CancellationToken token) {

		//var response = await _unitOfWork.RunWork(request, token);
		var response = await _service.AddData(request, token);

		return response.Match(
			_ => CreatedAtAction(nameof(AddDht22Data), response.Value),
			ProblemInController);
	}

	public Dht22DataController (
		IDht22DataService service//,
								 //IDht22SensorDataUnitOfWork unitOfWork
		) {
		_service = service;
		//_unitOfWork = unitOfWork;
	}

	private readonly IDht22DataService _service;
	//_
	//private readonly IDht22SensorDataUnitOfWork _unitOfWork;
}

/*
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "Hot",
  "DatesAvailable": [
	"2019-08-01T00:00:00-07:00",
	"2019-08-02T00:00:00-07:00"
  ],
  "TemperatureRanges": {
	"Cold": {
	  "High": 20,
	  "Low": -10
	},
	"Hot": {
	"High": 60,
	  "Low": 20

	}
  },
  "SummaryWords": [
	"Cool",
	"Windy",
	"Humid"
  ]
}
*/