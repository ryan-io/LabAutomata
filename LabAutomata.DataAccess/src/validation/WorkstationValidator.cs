using ErrorOr;
using LabAutomata.Dto.request;
using LabAutomata.Dto.response;

namespace LabAutomata.DataAccess.validation;
/// <summary>
/// Validates requests and response data transfer objects for the Workstation model
/// </summary>
public class WorkstationValidator : Validator<WorkstationResponse, WorkstationRequest> {
	public override ErrorOr<WorkstationResponse> ValidateResponse (WorkstationResponse response) {
		var errors = new List<Error>();
		if (response.Id < 0)
			errors.Add(Error.Validation("The assigned 'id' cannot be less than '0'"));

		if (string.IsNullOrWhiteSpace(response.Name))
			errors.Add(Error.Validation(description: "Workstation request name cannot be null or empty."));

		if (response.StationNumber <= 0)
			errors.Add(Error.Validation(description: "Workstation number cannot be less than '0' or '0'."));

		if (errors.Any()) return errors;

		return response;
	}

	public override ErrorOr<WorkstationRequest> ValidateRequest (WorkstationRequest request) {
		var errors = new List<Error>();

		if (string.IsNullOrWhiteSpace(request.Name))
			errors.Add(Error.Validation(description: "Workstation request name cannot be null or empty."));

		if (request.StationNumber <= 0)
			errors.Add(Error.Validation(description: "Workstation number cannot be less than '0' or '0'."));

		if (errors.Any()) return errors;

		return request;
	}

	/// <summary>
	/// Validates all workstation requests
	/// Returns early if a request is not validated successfully
	/// </summary>
	/// <param name="requests">The requests collection to validate</param>
	/// <returns>The list of requests if all validated successfully, otherwise a list of errors</returns>
	public override ErrorOr<List<WorkstationRequest>> ValidateRequests (List<WorkstationRequest> requests) {
		foreach (var request in requests) {
			var validated = ValidateRequest(request);
			if (validated.IsError)
				return validated.Errors;
		}

		return requests;
	}

	// TODO: worth improving?
	/// <summary>
	/// Validates all workstation responses
	/// Returns early if a response is not validated successfully
	/// </summary>
	/// <param name="responses">The responses collection to validate</param>
	/// <returns>The list of responses if all validated successfully, otherwise a list of errors</returns>
	public override ErrorOr<List<WorkstationResponse>> ValidateResponses (List<WorkstationResponse> responses) {
		foreach (var response in responses) {
			var validated = ValidateResponse(response);
			if (validated.IsError)
				return validated.Errors;
		}

		return responses;
	}
}
