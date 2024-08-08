using LabAutomata.DataAccess.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.response {
	public record WorkRequestResponse (
		int DbId,
		string Name,
		//int RequestId,
		string Program,
		string? Description,
		DateTime? Started,
		DateTime? Finished,
		EntityState EntityState) : RequestResponseBase, IResponse;

	public record WorkRequestUpsertResponse (
		int DbId,
		string Name,
		//int RequestId,
		string Program,
		string? Description,
		DateTime? Started,
		DateTime? Finished,
		bool WasUpdated) : RequestResponseBase, IResponse;
}
