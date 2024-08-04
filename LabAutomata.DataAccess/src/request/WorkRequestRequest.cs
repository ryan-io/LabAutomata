namespace LabAutomata.DataAccess.request {
	public record WorkRequestRequest (
			int Id,
			string Name,
			string Program,
			string? Description,
			DateTime? Started,
			DateTime? Finished);

	public record WorkRequestNewRequest (
		string Name,
		string Program,
		string? Description,
		DateTime? Started,
		DateTime? Finished);
}
