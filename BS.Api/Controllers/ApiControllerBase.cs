using BS.Api.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BS.Api.Controllers
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            var firstError = errors[0];

            HttpContext.Items[HttpContextItemKeys.Errors] = errors;

            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError

            };
            return Problem(statusCode: statusCode, title: firstError.Description);
        }
    }
}
