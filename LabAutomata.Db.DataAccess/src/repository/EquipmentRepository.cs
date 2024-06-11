using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.Db.DataAccess.src.repository {

	/// <summary>
	/// Represents a repository for managing Equipment entities in the database.
	/// </summary>
	public class EquipmentRepository : Repository<Equipment> {

		public override async Task<List<Equipment>> GetAll (CancellationToken ct = default) {
			return await DbCtx.Equipment
				.Include(e => e.Workstations)
				.Include(e => e.Manufacturer).ToListAsync(cancellationToken: ct);
		}

		public EquipmentRepository (ILabPostgreSqlDbContext dbCtx)
			: base(dbCtx, dbCtx.Equipment) {
		}
	}
}