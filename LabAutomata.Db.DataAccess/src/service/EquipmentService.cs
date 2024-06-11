using LabAutomata.Db.DataAccess.src.repository;
using LabAutomata.Db.models;

namespace LabAutomata.Db.DataAccess.src.service {

	/// <summary>
	/// Represents a service for managing Equipment entities.
	/// </summary>
	public class EquipmentService : Service<Equipment> {

		public EquipmentService (IRepository<Equipment> repository) : base(repository) {
		}
	}
}