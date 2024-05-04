using BS.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BS.Application.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? ex = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;

            var (statusCode, message) = ex switch
            {
                IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "An error occurred while processing your request.")
            };
            return Problem(statusCode: (int)statusCode, title: message);
        }
    }
}
