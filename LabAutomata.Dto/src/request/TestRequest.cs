using LabAutomata.Db.models;

namespace LabAutomata.Dto.request {
	public record TestRequest (
		string Name,
		string Description,
		int WorkstationId,
		ICollection<TestType> TestTypes) {
	}
}
