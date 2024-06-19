using LabAutomata.Db.models;

namespace LabAutomata.Dto.response {
	public record WorkRequestResponse (
		int Id,
		string Title,
		string Description,
		int Priority,
		int WorkstationId,
		Workstation? Workstation,
		ICollection<WorkstationType> RequiredTypes) {
	}
}
