using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.Db.DataAccess.src.repository;

/// <summary>
/// Represents a repository for managing Work Request entities in the database.
/// </summary>
public class WorkRequestRepository (ILabPostgreSqlDbContext dbCtx)
	: Repository<WorkRequest>(dbCtx, dbCtx.WorkRequests) {

	public override async Task<List<WorkRequest>> GetAll (CancellationToken ct = default) {
		return await DbCtx.WorkRequests
			.Include(wr => wr.Tests)
			.Include(wr => wr.Manufacturer)
			.ToListAsync(cancellationToken: ct);
	}
}