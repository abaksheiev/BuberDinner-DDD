using BS.Application.Http;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BS.Application.Controllers
{
    [ApiController]
    [Authorize]
    public class ApiControllerBase : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count is 0) {
                return Problem();
            }

            if (errors.All(error => error.Type == ErrorType.Validation))
            {
                return ValidationProblem(errors);
            }

            var firstError = errors[0];

            HttpContext.Items[HttpContextItemKeys.Errors] = errors;

            return Problem(firstError);
        }

        private IActionResult Problem(Error errror)
        {
            var statusCode = errror.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError

            };
            return Problem(statusCode: statusCode, title: errror.Description);
        }

        private IActionResult ValidationProblem(List<Error> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();

            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(
                    error.Code,
                    error.Description);
            }

            return ValidationProblem(modelStateDictionary);
        }
    }
}
