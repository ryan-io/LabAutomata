using ErrorOr;
using LabAutomata.DataAccess.common;
using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.response;
using LabAutomata.Db.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.service;

public class DhtSensorService : ServiceBase {
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

	public DhtSensorService (PostgreSqlDbContext dbContext) : base(dbContext) {
	}

	private string Name => nameof(DhtSensorService);

	private const string NotCreated = "Could not create a new Dht22 sensor.";
}