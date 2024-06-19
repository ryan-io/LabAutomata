using LabAutomata.DataAccess.mapper;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Dto.request;
using LabAutomata.Dto.response;

namespace LabAutomata.DataAccess.service {

	/// <summary>
	/// Represents a service for managing Equipment entities.
	/// </summary>
	public class EquipmentService : Service<Equipment, EquipmentRequest, EquipmentResponse> {

		public EquipmentService (
			IRepository<Equipment> repository,
			IMapper<Equipment, EquipmentRequest, EquipmentResponse> mapper)
			: base(repository, mapper) {
		}
	}
}