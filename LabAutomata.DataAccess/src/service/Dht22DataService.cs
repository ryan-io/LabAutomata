using ErrorOr;
using LabAutomata.DataAccess.common;
using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.response;
using LabAutomata.Db.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.service;

public class Dht22DataService : ServiceBase {
	public async Task<ErrorOr<Dht22DataResponse>> AddData (Dht22DataNewRequest request, CancellationToken token) {
		var model = request.ToDbModel();
		var result = await DbContext.Dht22Data.AddAsync(model, token);
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

	public async Task<ErrorOr<IList<Dht22DataResponse>>> GetData (int dhtSensorId, CancellationToken token) {
		// we'll retrieve all fields for the target sensor
		var sensor = await DbContext.Dht22Sensors
			.Where(s => s.Id == dhtSensorId)
			.FirstAsync(token);

		if (sensor.Data == null) {
			return Errors.Db.CouldNotGetAll(Name, CouldNotGet);
		}

		return sensor.Data
			.Select(point => point.ToResponse(EntityState.Unchanged))
			.ToList();
	}

	/// <summary>
	/// This method should be used if you have a request object with a valid Dht22Sensor instance
	/// </summary>
	public async Task<ErrorOr<IList<Dht22DataResponse>>> GetData (Dht22DataRequest request, CancellationToken token) {
		return await GetData(request.Dht22Sensor.Id, token);
	}

	public async Task<ErrorOr<Dht22DataResponse>> DeleteData (Dht22DataRequest request, CancellationToken token) {
		var dataPoint = await DbContext.Dht22Data.FirstOrDefaultAsync(d => d.Id == request.Id, token);

		if (dataPoint == null) {
			// return error; data is not present in the db
			return Errors.Db.CouldNotDelete(Name, GetFailedDeleteDescription(request));
		}

		DbContext.Dht22Data.Remove(dataPoint);
		return dataPoint.ToResponse(EntityState.Deleted);
	}

	/// <inheritdoc />
	public Dht22DataService (PostgreSqlDbContext dbContext) : base(dbContext) {
	}

	private static string GetFailedDeleteDescription (Dht22DataRequest request) {
		return $"Could not delete entity from request {request.Dht22Sensor.Name}";
	}

	private string Name => nameof(Dht22DataService);

	private const string CouldNotGet = "Could not get data for the provided sensor id.";

	private const string NotCreated = "Entry returned could not be created.";
}