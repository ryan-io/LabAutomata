using LabAutomata.DataAccess.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.response {
	public record WorkstationResponse (
		int DbId,
		string Name,
		int StationNumber,
		string? Description,
		DateTime Created,
		LocationResponse? Location,
		EntityState EntityState) : RequestResponseBase, IResponse;

	public record WorkstationUpsertResponse (
		int DbId,
		string Name,
		int StationNumber,
		string? Description,
		DateTime Created,
		LocationResponse? Location,
		bool WasUpdated) : RequestResponseBase, IResponse;
}
