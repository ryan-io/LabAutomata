using ErrorOr;
using LabAutomata.DataAccess.common;
using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.response;
using LabAutomata.Db.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.service;

public class Dht22DataService : ServiceBase {
	public async Task<ErrorOr<Dht22DataResponse>> Add (Dht22DataRequest request, CancellationToken token) {
		var model = Dht22DataRequest.NewRequest(request);
		var result = await DbContext.Dht22Data.AddAsync(model, token);

		if (result.State == EntityState.Added) {
			await DbContext.SaveChangesAsync(token);
			var response = Dht22DataResponse.NewResponse(result.Entity, EntityState.Added);
			return response;
		}

		if (result.State == EntityState.Unchanged) {
			return Dht22DataResponse.NewResponse(result.Entity);
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
			.Select(point => Dht22DataResponse.NewResponse(point))
			.ToList();
	}

	public async Task<ErrorOr<Dht22DataResponse>> Get (Dht22DataRequest request, CancellationToken token) {

	}

	/// <inheritdoc />
	public Dht22DataService (PostgreSqlDbContext dbContext) : base(dbContext) {
	}


	private string Name => nameof(Dht22DataService);

	private const string CouldNotGet = "Could not get data for the provided sensor id.";

	private const string NotCreated = "Entry returned could not be created.";
}