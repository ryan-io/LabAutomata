using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.Db.repository {

	/// <summary>
	/// Represents a repository for managing Work Request entities in the database.
	/// </summary>
	public class WorkstationRepository (ILabPostgreSqlDbContext dbCtx)
		: Repository<Workstation>(dbCtx, dbCtx.Workstations) {

		public override async Task<List<Workstation>> GetAll (CancellationToken ct = default) {
			return await DbCtx.Workstations
				.Include(ws => ws.Tests)
				.ToListAsync(cancellationToken: ct);
		}
	}
}