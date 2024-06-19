using LabAutomata.Db.models;
using LabAutomata.Dto.request;
using LabAutomata.Dto.response;

namespace LabAutomata.DataAccess.mapper;

public class WorkstationMapper : IMapper<Workstation, WorkstationRequest, WorkstationResponse> {
	/// <summary>
	/// Maps a WorkstationRequestCreate object to a Workstation model.
	/// </summary>
	/// <param name="createRequest">The request object containing the data for creating the Workstation.</param>
	/// <returns>The mapped Workstation model.</returns>
	public Workstation ToModel (WorkstationRequest createRequest) {
		return new Workstation() {
			Name = createRequest.Name,
			StationNumber = createRequest.StationNumber,
			Description = createRequest.Description,
			LocationId = createRequest.LocationId,
			Location = createRequest.Location,
			Types = createRequest.Types,
			Equipment = createRequest.Equipment,
			Tests = createRequest.Tests
		};
	}

	/// <summary>
	/// Maps a Workstation model to a WorkstationResponse object.
	/// </summary>
	/// <param name="model">The Workstation model to be mapped.</param>
	/// <returns>The mapped WorkstationResponse object.</returns>
	public WorkstationResponse ToResponse (Workstation model) {
		return new WorkstationResponse(
			model.Id,
			model.Name,
			model.StationNumber,
			model.Description,
			model.LocationId,
			model.Location,
			model.Types,
			model.Equipment,
			model.Tests);
	}


}