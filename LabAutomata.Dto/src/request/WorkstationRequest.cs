using LabAutomata.Db.models;

namespace LabAutomata.Dto.request {
	public record WorkstationRequest (
		string Name,
		int StationNumber,
		string? Description,
		int LocationId,
		Location? Location,
		ICollection<WorkstationType> Types,
		ICollection<Equipment> Equipment,
		ICollection<Test> Tests) {
	}
}
