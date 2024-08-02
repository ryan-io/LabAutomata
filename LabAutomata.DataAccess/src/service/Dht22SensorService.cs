using ErrorOr;
using LabAutomata.DataAccess.common;
using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.response;
using LabAutomata.Db.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.service;

public class Dht22SensorService : ServiceBase {
	public async Task<ErrorOr<Dht22SensorResponse>> AddSensor (Dht22SensorNewRequest request, CancellationToken token) {
		var model = request.ToDbModel();
		var result = await DbContext.Dht22Sensors.AddAsync(model, token);
		var response = result.ToResponse();

		if (result.State == EntityState.Added) {
			await DbContext.SaveChangesAsync(token);
			return response;
		}

		if (result.State == EntityState.Unchanged) {
			return response;
		}

		return Errors.Db.CouldNotCreate(Name, NotCreated);
	}

	public async Task<Dht22SensorUpsertResponse> UpsertSensor (Dht22SensorRequest request, CancellationToken token) {
		var model = request.ToDbModel();
		var result = DbContext.Dht22Sensors.Update(model);
		var response = result.ToUpsertResponse();
		await DbContext.SaveChangesAsync(token);
		return response;
	}

	public Dht22SensorService (PostgreSqlDbContext dbContext) : base(dbContext) {
	}

	protected override string Name => nameof(Dht22SensorService);

	private const string NotCreated = "Could not create a new Dht22 sensor.";
}