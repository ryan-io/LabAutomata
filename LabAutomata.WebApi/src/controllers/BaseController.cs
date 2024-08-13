using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LabAutomata.WebApi.controllers {
	/* Reference for REST API response returns:
	 *		https://www.mailersend.com/help/rest-api-response-codes
	 * Post-template:
	 *      Query factory to create a new model
	 *      Check if the factory return a discriminated union (ErrorOr)
	 *          result.IsError
	 *      Invoked user service to create the model and serialize to db context
	 *      Optional: Map the response from the factory method in step 1
	 *      Return the ErrorOr<Created> discriminated union via 'Match' method
	 *      Example:            ** ProblemInController is defined in this base controller
	 *          	var addToRepositoryResult = m_demoService.CreateMockDemoItem(createNewResult.Value);
					var response = MapResponse(createNewResult.Value);
					return addToRepositoryResult.Match(
						item => CreatedAtAction(
							nameof(CreateMockDemoItem),
							new { id = createNewResult.Value.Id },
							response),
						ProblemInController);
	 */
	// reference a video from Amichai
	//		https://www.youtube.com/watch?v=PmDJIooZjBE
	/*
	 * PUT:		when you have a known URI & idempotent (updating something)
	 * POST:	when you want to create something new in the database
	 */
	[ApiController]
	[Route("api/[controller]/")]
	public class BaseController : Controller {

		protected IActionResult ProblemInController (List<Error> errors) {
			if (errors.All(e => e.Type == ErrorType.Validation)) {
				// create model state dictionary
				var dict = new ModelStateDictionary();

				foreach (var error in errors)
					dict.AddModelError(error.Code, error.Description);

				return ValidationProblem(dict);
			}

			if (errors.Any(e => e.Type == ErrorType.Unexpected)) {
				return Problem();
			}

			var code = StatusCodes.Status500InternalServerError;

			switch (errors[0].Type) {
				case ErrorType.Failure:
					code = StatusCodes.Status417ExpectationFailed;
					break;

				case ErrorType.Validation:
					code = StatusCodes.Status400BadRequest;
					break;

				case ErrorType.Conflict:
					code = StatusCodes.Status409Conflict;
					break;

				case ErrorType.NotFound:
					code = StatusCodes.Status404NotFound;
					break;

				case ErrorType.Unauthorized:
					code = StatusCodes.Status401Unauthorized;
					break;
			}

			return Problem(
				statusCode: code,
				instance: code.ToString(),
				detail: errors[0].Description);
		}
	}
}