using ErrorOr;
using LabAutomata.DataAccess.common;
using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.response;
using LabAutomata.Db.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.service;

public interface IManufacturerService {
	Task<ErrorOr<ManufacturerResponse>> AddManufacturer (ManufacturerNewRequest request, CancellationToken token);
	Task<ManufacturerUpsertResponse> UpsertLocation (ManufacturerRequest request, CancellationToken token);
}

public class ManufacturerService : ServiceBase, IManufacturerService {
	public async Task<ErrorOr<ManufacturerResponse>> AddManufacturer (ManufacturerNewRequest request, CancellationToken token) {
		await using var ctx = await DbContextFactory.CreateDbContextAsync(token);

		var model = request.ToDbModel();
		var result = await ctx.Manufacturers.AddAsync(model, token);
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

	public async Task<ManufacturerUpsertResponse> UpsertLocation (ManufacturerRequest request, CancellationToken token) {
		await using var ctx = await DbContextFactory.CreateDbContextAsync(token);

		var model = request.ToDbModel();
		var result = ctx.Manufacturers.Update(model);
		var response = result.ToUpsertResponse();
		await ctx.SaveChangesAsync(token);
		return response;
	}

	public ManufacturerService (IDbContextFactory<PostgreSqlDbContext> dbContextFactory) : base(dbContextFactory) { }

	protected override string Name => nameof(ManufacturerService);

	private const string NotCreated = "Could not created a new manufacturer.";
}