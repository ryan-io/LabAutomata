using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.Db.DataAccess.src.repository {

	/// <summary>
	/// Represents a repository for managing DhtSensor entities in the database.
	/// </summary>
	public class DhtSensorRepository : Repository<DhtSensor> {

		public DhtSensorRepository (ILabPostgreSqlDbContext dbCtx)
			: base(dbCtx, dbCtx.DhtSensors) {
		}

		public override async Task<List<DhtSensor>> GetAll (CancellationToken ct = default) {
			return await DbCtx.DhtSensors
				.Include(ds => ds.Data)
				.ToListAsync(cancellationToken: ct);
		}
	}
}