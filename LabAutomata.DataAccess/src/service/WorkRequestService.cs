using ErrorOr;
using LabAutomata.DataAccess.common;
using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.response;
using LabAutomata.Db.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.service;

public interface IWorkRequestService {
	Task<ErrorOr<WorkRequestResponse>> CreateWorkRequest (
		WorkRequestNewRequest request, CancellationToken token);
}

public class WorkRequestService : ServiceBase, IWorkRequestService {
	public async Task<ErrorOr<WorkRequestResponse>> CreateWorkRequest (
		WorkRequestNewRequest request, CancellationToken token) {
		await using var ctx = await DbContextFactory.CreateDbContextAsync(token);

		var model = request.ToDbModel();
		var result = ctx.WorkRequests.Add(model);
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

	public WorkRequestService (IDbContextFactory<PostgreSqlDbContext> dbContextFactory)
		: base(dbContextFactory) { }

	protected override string Name => nameof(WorkRequestService);

	private const string NotCreated = "Could not create a new work request.";
}