using ErrorOr;

namespace LabAutomata.DataAccess.validation;

public interface IValidator<TResponse, TRequest> {
	/// <summary>
	/// Validates the response.
	/// </summary>
	/// <param name="response">The response to validate.</param>
	/// <returns>An ErrorOr object containing the validated response or an error.</returns>
	ErrorOr<TResponse> ValidateResponse (TResponse response);

	/// <summary>
	/// Validates the request.
	/// </summary>
	/// <param name="request">The request to validate.</param>
	/// <returns>An ErrorOr object containing the validated request or an error.</returns>
	ErrorOr<TRequest> ValidateRequest (TRequest request);
}