using ErrorOr;
using LabAutomata.Dto.request;
using LabAutomata.Dto.response;
using NotImplementedException = System.NotImplementedException;

namespace LabAutomata.DataAccess.validation
{
    public class WorkstationValidator : Validator<WorkstationResponse, WorkstationRequest> {
		public override ErrorOr<WorkstationResponse> ValidateResponse (WorkstationResponse response) {
			throw new NotImplementedException();
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
	}

	/// <summary>
	/// Represents an abstract class for validating responses and requests.
	/// </summary>
	/// <typeparam name="TResponse">The type of the response.</typeparam>
	/// <typeparam name="TRequest">The type of the request.</typeparam>
	public abstract class Validator<TResponse, TRequest> : IValidator<TResponse, TRequest> {

		/// <summary>
		/// Validates the response.
		/// </summary>
		/// <param name="response">The response to validate.</param>
		/// <returns>An ErrorOr object containing the validated response or an error.</returns>
		public abstract ErrorOr<TResponse> ValidateResponse (TResponse response);

		/// <summary>
		/// Validates the request.
		/// </summary>
		/// <param name="request">The request to validate.</param>
		/// <returns>An ErrorOr object containing the validated request or an error.</returns>
		public abstract ErrorOr<TRequest> ValidateRequest (TRequest request);
	}
}
