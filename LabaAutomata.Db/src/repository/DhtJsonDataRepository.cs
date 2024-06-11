using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.Db.repository {

	/// <summary>
	/// Represents a repository for managing DhtJsonData entities in the database.
	/// </summary>
	public class DhtJsonDataRepository : Repository<DhtJsonData> {
		public DhtJsonDataRepository (ILabPostgreSqlDbContext dbCtx)
			: base(dbCtx, dbCtx.DhtJsonData) {
		}

		public override async Task<List<DhtJsonData>> GetAll (CancellationToken ct = default) {
			return await DbCtx.DhtJsonData
				.Include(djd => djd.DhtSensor)
				.ToListAsync(cancellationToken: ct);
		}
	}
}
