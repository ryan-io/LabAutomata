using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LabAutomata.WebApi.src.controllers {
    public class BaseController : Controller {
        protected IActionResult ProblemInController (List<Error> errors) {
            if (errors.All(e => e.Type == ErrorType.Validation)) {
                // create model state dictionary
                var dict = new ModelStateDictionary();

                foreach (var error in errors)
                    dict.AddModelError(error.Code, error.Description);

                return ValidationProblem();
            }

            if (errors.Any(e => e.Type == ErrorType.Unexpected))
                return Problem();

            int code = StatusCodes.Status500InternalServerError;

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
