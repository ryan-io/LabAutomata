namespace LabAutomata.Dto.response {
	public record LocationResponse (
		int Id,
		string Name,
		string Address,
		string? Description) {
	}
}
