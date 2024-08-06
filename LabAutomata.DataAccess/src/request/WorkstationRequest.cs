using LabAutomata.DataAccess.common;

namespace LabAutomata.DataAccess.request {
	public record WorkstationRequest (
			int Id,
			string Name,
			string Location,
			string? Description,
			DateTime? InstallationDate,
			DateTime? LastMaintenanceDate) : RequestResponseBase, IRequest;

	public record WorkstationNewRequest (
		string Name,
		string Location,
		string? Description,
		DateTime? InstallationDate,
		DateTime? LastMaintenanceDate) : RequestResponseBase, IRequest;
}
