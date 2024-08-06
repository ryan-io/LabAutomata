using LabAutomata.DataAccess.common;
using LabAutomata.DataAccess.request;
using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.unit_of_work;

public interface IDht22SensorDataUnitOfWork {
	Task<Dht22Sensor> RunWork (Dht22AddDataToSensorRequest request, CancellationToken token);
}

/// <summary>
/// A transaction to add a new data point to a sensor
/// </summary>
public class Dht22SensorDataUnitOfWork : UnitOfWork, IDht22SensorDataUnitOfWork {
	public async Task<Dht22Sensor> RunWork (Dht22AddDataToSensorRequest request, CancellationToken token) {
		//TODO: should this be refactored? any benefits? would it really be cleaner to isolate this into a helper method? it would still require a using statement for scope and it would still need to be awaited with the current implementation
		await using var ctx = await DbContextFactory.CreateDbContextAsync(token);

		int sensorDbId = request.DbId;

		// reference Microsoft documentation on change tracking:
		// https://learn.microsoft.com/en-us/ef/core/change-tracking/
		Dht22Sensor? sensor = ctx.Dht22Sensors
			.Include(s => s.Location)
			.Include(s => s.Data)
			.FirstOrDefault(sensor => sensor.Id == sensorDbId);

		ArgumentNullException.ThrowIfNull(sensor, $"Could not find sensor with id {request.DbId}.");

		var dataRequest = new Dht22DataRequest(request.DbId, request.JsonString, sensor);
		sensor.Data.Add(dataRequest.ToDbModel());
		// add the new dataRequest DbModel to the database
		//ctx.Dht22Data.Add(dataRequest.ToDbModel());

		// get the updated sensor with it's data
		// the JOINs below are at the same level; no need for 'ThenInclude'
		//sensor = ctx.Dht22Sensors
		//	.Include(s => s.Location)
		//	.Include(s => s.Data)
		//	.FirstOrDefault(s => s.Id == sensorDbId);

		ArgumentNullException.ThrowIfNull(sensor, $"Could not find a sensor with the id {sensorDbId}");

		await ctx.SaveChangesAsync(token);

		return sensor;
	}

	public Dht22SensorDataUnitOfWork (IDbContextFactory<PostgreSqlDbContext> dbContextFactory)
		: base(dbContextFactory) { }

	private const string NoDht22Sensor = "Dht22DataRequest must have a valid Dht22Sensor object assigned.";
}