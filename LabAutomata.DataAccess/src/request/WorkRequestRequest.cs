using LabAutomata.DataAccess.common;

namespace LabAutomata.DataAccess.request {
	public record WorkRequestRequest (
		int Id,
		string Name,
		int RequestId,
		string Program,
		string? Description,
		DateTime Started,
		DateTime Finished) : RequestResponseBase, IRequest;

	public record WorkRequestNewRequest (
		string Name,
		int RequestId,
		string Program,
		string? Description,
		DateTime Started,
		DateTime Finished) : RequestResponseBase, IRequest;
}
