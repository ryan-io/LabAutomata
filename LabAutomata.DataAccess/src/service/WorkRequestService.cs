using ErrorOr;
using LabAutomata.DataAccess.common;
using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.response;
using LabAutomata.Db.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.service;

public class WorkRequestService : ServiceBase {
	public async Task<ErrorOr<WorkRequestResponse>> CreateWorkRequest (WorkRequestNewRequest request,
		CancellationToken token) {
		var model = request.ToDbModel();
		var result = DbContext.WorkRequests.Add(model);
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

	public WorkRequestService (PostgreSqlDbContext dbContext) : base(dbContext) {
	}

	protected override string Name => nameof(WorkRequestService);

	private const string NotCreated = "Could not create a new work request.";
}