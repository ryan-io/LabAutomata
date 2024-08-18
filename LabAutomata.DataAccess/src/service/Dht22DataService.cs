using ErrorOr;
using LabAutomata.DataAccess.common;
using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.response;
using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using rbcl;

namespace LabAutomata.DataAccess.service;

public interface IDht22DataService {
	Task<ErrorOr<Dht22DataResponse>> AddData (Dht22AddDataToSensorRequest request, CancellationToken token);
	Task<ErrorOr<IList<Dht22DataResponse>>> GetData (int dhtSensorId, CancellationToken token);

	/// <summary>
	/// This method should be used if you have a request object with a valid Dht22Sensor instance
	/// </summary>
	Task<ErrorOr<IList<Dht22DataResponse>>> GetData (Dht22DataRequest request, CancellationToken token);

	Task<ErrorOr<Dht22DataResponse>> DeleteData (Dht22DataRequest request, CancellationToken token);
}

public class Dht22DataService : ServiceBase, IDht22DataService {
	public async Task<ErrorOr<Dht22DataResponse>> AddData (Dht22AddDataToSensorRequest request, CancellationToken token) {
		await using var ctx = await DbContextFactory.CreateDbContextAsync(token);

		var json = request.JsonString;
		var jsonValidated = _jsonValidator.Validate(ref json);

		if (jsonValidated.HadErrors) {
			var errors = Errors.Validate.InvalidJson(jsonValidated.Errors!);
			return ErrorOr<Dht22DataResponse>.From(errors);
		}

		var model = new Dht22Data() {
			Dht22SensorId = request.SensorDbId,
			JsonString = jsonValidated.Json
		};

		var result = ctx.Dht22Data.Attach(model);

		if (result.State == EntityState.Added) {
			await ctx.SaveChangesAsync(token);
			await ctx.Dht22Data
				.Entry(result.Entity)
				.Reference(e => e.Dht22Sensor)
				.LoadAsync(token);
			return result.ToResponse();
		}

		if (result.State == EntityState.Unchanged) {
			return result.ToResponse();
		}

		return Errors.Db.CouldNotCreate(Name, NotCreated);
	}

	public async Task<ErrorOr<IList<Dht22DataResponse>>> GetData (int dhtSensorId, CancellationToken token) {
		await using var ctx = await DbContextFactory.CreateDbContextAsync(token);

		// we'll retrieve all fields for the target sensor
		var sensor = await ctx.Dht22Sensors
			.Where(s => s.Id == dhtSensorId)
			.FirstAsync(token);

		return sensor.Data
			.Select(point => point.ToResponse(EntityState.Unchanged))
			.ToList();
	}

	/// <summary>
	/// This method should be used if you have a request object with a valid Dht22Sensor instance
	/// </summary>
	public async Task<ErrorOr<IList<Dht22DataResponse>>> GetData (Dht22DataRequest request, CancellationToken token) {
		return await GetData(request.Dht22Sensor.DbId, token);
	}

	public async Task<ErrorOr<Dht22DataResponse>> DeleteData (Dht22DataRequest request, CancellationToken token) {
		await using var ctx = await DbContextFactory.CreateDbContextAsync(token);

		var dataPoint = await ctx.Dht22Data.FirstOrDefaultAsync(d => d.Id == request.DbId, token);

		if (dataPoint == null) {
			// return error; data is not present in the db
			return Errors.Db.CouldNotDelete(Name, GetFailedDeleteDescription(request));
		}

		ctx.Dht22Data.Remove(dataPoint);
		await ctx.SaveChangesAsync(token);
		return dataPoint.ToResponse(EntityState.Deleted);
	}

	/// <inheritdoc />
	public Dht22DataService (
		IDbContextFactory<PostgreSqlDbContext> dbContextFactory, IJsonValidator jsonValidator)
		: base(dbContextFactory) {
		_jsonValidator = jsonValidator;
	}

	private static string GetFailedDeleteDescription (Dht22DataRequest request) {
		return $"Could not delete entity from request {request.Dht22Sensor.Name}";
	}

	protected override string Name => nameof(Dht22DataService);

	private readonly IJsonValidator _jsonValidator;

	private const string NotCreated = "Entry returned could not be created.";
}