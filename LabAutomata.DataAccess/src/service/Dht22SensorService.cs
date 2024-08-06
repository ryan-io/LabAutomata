using ErrorOr;
using LabAutomata.DataAccess.common;
using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.response;
using LabAutomata.Db.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.service;

public interface IDht22SensorService {
	Task<ErrorOr<Dht22SensorResponse>> AddSensor (Dht22SensorNewRequest request, CancellationToken token);
	Task<Dht22SensorUpsertResponse> UpsertSensor (Dht22SensorRequest request, CancellationToken token);
}

public class Dht22SensorService : ServiceBase, IDht22SensorService {
	public async Task<ErrorOr<Dht22SensorResponse>> AddSensor (Dht22SensorNewRequest request, CancellationToken token) {
		await using var ctx = await DbContextFactory.CreateDbContextAsync(token);

		var model = request.ToDbModel();
		// we can use AddAsync here
		var result = ctx.Dht22Sensors.Add(model);
		var response = result.ToResponse();

		if (result.State == EntityState.Added) {
			await ctx.SaveChangesAsync(token);
			return response;
		}

		if (result.State == EntityState.Unchanged) {
			return response;
		}

		return Errors.Db.CouldNotCreate(Name, NotCreated);
	}

	public async Task<Dht22SensorUpsertResponse> UpsertSensor (Dht22SensorRequest request, CancellationToken token) {
		await using var ctx = await DbContextFactory.CreateDbContextAsync(token);

		var model = request.ToDbModel();
		var result = ctx.Dht22Sensors.Update(model);
		var response = result.ToUpsertResponse();
		await ctx.SaveChangesAsync(token);
		return response;
	}

	public Dht22SensorService (IDbContextFactory<PostgreSqlDbContext> dbContextFactory)
		: base(dbContextFactory) {
	}

	protected override string Name => nameof(Dht22SensorService);

	private const string NotCreated = "Could not create a new Dht22 sensor.";
}