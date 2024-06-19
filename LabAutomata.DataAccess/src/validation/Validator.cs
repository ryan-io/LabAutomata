using ErrorOr;

namespace LabAutomata.DataAccess.validation {
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

		/// <summary>
		/// Validates a list of requests.
		/// </summary>
		/// <param name="requests">The list of requests to validate.</param>
		/// <returns>An ErrorOr object containing the validated list of requests or an error.</returns>
		public abstract ErrorOr<List<TRequest>> ValidateRequests (List<TRequest> requests);

		/// <summary>
		/// Validates a list of responses.
		/// </summary>
		/// <param name="responses">The list of responses to validate.</param>
		/// <returns>An ErrorOr object containing the validated list of responses or an error.</returns>
		public abstract ErrorOr<List<TResponse>> ValidateResponses (List<TResponse> responses);
	}
}
