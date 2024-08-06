using ErrorOr;
using LabAutomata.DataAccess.common;
using LabAutomata.DataAccess.response;
using LabAutomata.Db.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.service;

public interface IWorkstationService {
	Task<ErrorOr<IList<WorkstationResponse>>> GetWorkstations (CancellationToken token);
}

/// <summary>
/// Service class for managing Workstation entities.
/// </summary>
public class WorkstationService : ServiceBase, IWorkstationService {

	public async Task<ErrorOr<IList<WorkstationResponse>>> GetWorkstations (CancellationToken token) {
		await using var ctx = await DbContextFactory.CreateDbContextAsync(token);

		var workstations = ctx.Workstations
			.Include(ws => ws.Location)
			.Select(ws => ws.ToResponse())
			.ToList();

		if (workstations.Count < 1) {
			return Error.NotFound(description: NoWorkstationsInDb);
		}

		return workstations;
	}


	/// <summary>
	/// Initializes a new instance of the <see cref="WorkstationService"/> class.
	/// </summary>
	public WorkstationService (IDbContextFactory<PostgreSqlDbContext> dbContextFactory
		) : base(dbContextFactory) { }

	protected override string Name => nameof(WorkstationService);

	private const string NoWorkstationsInDb = "There are not workstations in the database.";
}