using LabAutomata.DataAccess.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.response {
	public record WorkstationResponse (
		int DbId,
		string Name,
		int StationNumber,
		string? Description,
		DateTime Created,
		Location? Location,
		EntityState EntityState) : RequestResponseBase, IResponse;

	public record WorkstationUpsertResponse (
		int DbId,
		string Name,
		int StationNumber,
		string? Description,
		DateTime Created,
		Location? Location,
		bool WasUpdated) : RequestResponseBase, IResponse;
}
