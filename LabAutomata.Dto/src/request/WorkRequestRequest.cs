using LabAutomata.Dto.response;

namespace LabAutomata.Dto.request {
	public record WorkRequestRequest (
		string Title,
		string Description,
		int Priority,
		int WorkstationId,
		ICollection<WorkstationTypeResponse> RequiredTypes) {
	}
}
