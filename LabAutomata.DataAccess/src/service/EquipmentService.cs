using LabAutomata.Db.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.service {
	public interface IEquipmentService {
	}

	/// <summary>
	/// Represents a service for managing Equipment entities.
	/// </summary>
	public class EquipmentService : ServiceBase, IEquipmentService {

		public EquipmentService (IDbContextFactory<PostgreSqlDbContext> dbFactory)
			: base(dbFactory) { }

		protected override string Name => nameof(EquipmentService);
	}
}