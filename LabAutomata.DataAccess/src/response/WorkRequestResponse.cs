using LabAutomata.DataAccess.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.response {
	public record WorkRequestResponse (
		int DbId,
		string Name,
		string Program,
		string? Description,
		DateTime? Started,
		DateTime? Finished,
		EntityState EntityState) : RequestResponseBase;

	public record WorkRequestUpsertResponse (
		int DbId,
		string Name,
		string Program,
		string? Description,
		DateTime? Started,
		DateTime? Finished,
		bool WasUpdated) : RequestResponseBase;
}
