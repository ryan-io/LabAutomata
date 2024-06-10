using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.Db.service {

	/// <summary>
	/// Represents a service for managing Equipment entities.
	/// </summary>
	public class EquipmentService : Service<Equipment> {

		public EquipmentService (IRepository<Equipment> repository) : base(repository) {
		}
	}
}