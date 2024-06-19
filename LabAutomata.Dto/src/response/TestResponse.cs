using LabAutomata.Db.models;

namespace LabAutomata.Dto.response {
	public record TestResponse (
		int Id,
		string Name,
		string Description,
		int WorkstationId,
		Workstation? Workstation,
		ICollection<TestType> TestTypes) {
	}
}
