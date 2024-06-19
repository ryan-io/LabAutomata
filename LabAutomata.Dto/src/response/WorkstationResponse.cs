using LabAutomata.Db.models;

namespace LabAutomata.Dto.response {
	public record WorkstationResponse (
		int Id,
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
