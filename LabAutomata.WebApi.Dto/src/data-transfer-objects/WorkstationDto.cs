using LabAutomata.Db.models;

namespace LabAutomata.WebApi.Dto.src.data_transfer_objects {
	public record WorkstationDto (
		string Name,
		int StationNumber,
		string? Description,
		int? LocationId,
		Location? Location,
		ICollection<WorkstationType> Types,
		ICollection<Equipment>? Equipment,
		ICollection<Test>? Tests) {
	}
}
