using ErrorOr;
using LabAutomata.DataAccess.common;
using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.service;
using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.unit_of_work;

public interface IDht22SensorDataUnitOfWork {
	Task<ErrorOr<bool>> RunWork (
		Dht22AddDataToSensorRequest request,
		CancellationToken token);
}

/// <summary>
/// A transaction to add a new data point to a sensor
/// </summary>
public class Dht22SensorDataUnitOfWork : UnitOfWork, IDht22SensorDataUnitOfWork {
	public async Task<ErrorOr<bool>> RunWork (Dht22AddDataToSensorRequest request, CancellationToken token) {
		//TODO: should this be refactored? any benefits? would it really be cleaner to isolate this into a helper method? it would still require a using statement for scope and it would still need to be awaited with the current implementation
		await using var ctx = await DbContextFactory.CreateDbContextAsync(token);

		// allocation for errors
		_errors.Clear();
		int sensorDbId = request.SensorDbId;

		//TODO: give this line some thought; the SRP here is to run a unit of work in the context
		//		of a database transactions
		// since this is an "all or nothing" process, I think it makes sense to also validate the data
		//		we passed in the 'Dht22AddDataToSensorRequest' to ensure validity
		var jsonValidation = _jsonValidator.Validate(request.JsonString);

		// if we could not parse the json string, add an error to the errors list
		if (jsonValidation.IsError) {
			_errors.AddRange(jsonValidation.Errors);
		}

		// reference Microsoft documentation on change tracking:
		// https://learn.microsoft.com/en-us/ef/core/change-tracking/
		Dht22Sensor? sensor = ctx.Dht22Sensors
			.Include(sensor => sensor.Location)
			.Include(sensor => sensor.Data)
			.FirstOrDefault(sensor => sensor.Id == sensorDbId);

		//// if we could not get the sensor for the db, add an error to the errors list
		if (sensor == null) {
			_errors.Add(Errors.Db.CouldNotGet(nameof(Errors.Db.CouldNotGet),
				$"Could not find a sensor with the id {sensorDbId}"));

			return false; //ErrorOr<Dht22SensorResponse>.From(_errors);
		}

		var replace = new ReplaceApostopheWithQuote();
		var requestJsonString = request.JsonString;
		var jsonString = replace.Modify(ref requestJsonString);
		var newRequest = new Dht22DataNewRequest(jsonString, sensor.ToResponse());

		ctx.Dht22Data.Add(newRequest.ToDbModel());

		//var dataRequest = new Dht22DataRequest(
		//	request.SensorDbId,
		//	jsonString,
		//	sensor.ToResponse());

		if (!_errors.Any()) {
			await ctx.SaveChangesAsync(token);  // save to db
		}

		// return either a response (good) or problem (bad)
		return true; //sensor.ToResponse();
	}

	public Dht22SensorDataUnitOfWork (
		IDbContextFactory<PostgreSqlDbContext> dbContextFactory,
		IJsonValidator jsonValidator)
		: base(dbContextFactory) {
		_jsonValidator = jsonValidator;
	}

	private readonly IJsonValidator _jsonValidator;
	private readonly List<Error> _errors = [];
}