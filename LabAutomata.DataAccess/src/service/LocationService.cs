using ErrorOr;
using LabAutomata.DataAccess.common;
using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.response;
using LabAutomata.Db.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.service;

public interface ILocationService {
	Task<ErrorOr<LocationResponse>> AddLocation (LocationNewRequest request, CancellationToken token);
	Task<LocationUpsertResponse> UpsertLocation (LocationRequest request, CancellationToken token);
}

public class LocationService : ServiceBase, ILocationService {
	public async Task<ErrorOr<LocationResponse>> AddLocation (LocationNewRequest request, CancellationToken token) {
		await using var ctx = await DbContextFactory.CreateDbContextAsync(token);

		var model = request.ToDbModel();
		var result = await ctx.Locations.AddAsync(model, token);
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
	public async Task<LocationUpsertResponse> UpsertLocation (LocationRequest request, CancellationToken token) {
		await using var ctx = await DbContextFactory.CreateDbContextAsync(token);

		var model = request.ToDbModel();
		var result = ctx.Locations.Update(model);
		var response = result.ToUpsertResponse();
		await ctx.SaveChangesAsync(token);
		return response;
	}

	public LocationService (IDbContextFactory<PostgreSqlDbContext> dbContextFactory) : base(dbContextFactory) { }

	protected override string Name => nameof(LocationService);

	private const string NotCreated = "Could not created a new location.";
}