using LabAutomata.Db.common;
using LabAutomata.Db.models;

namespace LabAutomata.Db.repository;

/// <summary>
/// Represents a repository for managing Location entities in the database.
/// </summary>
public class LocationRepository : Repository<Location> {
	/// <summary>
	/// Represents a repository for managing Location entities in the database.
	/// </summary>
	public LocationRepository (ILabPostgreSqlDbContext dbCtx) : base(dbCtx, dbCtx.Location) {
	}
}