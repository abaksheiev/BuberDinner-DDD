using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BS.Api.Filters
{
    public class ErrorHandlingFilterAttributes : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var ex = context.Exception;

            var problemDetails = new ProblemDetails
            {
                Type= "https://tools.ietf.org/html/rfc9110#section-15.6.1",
                Title = "An error occurred while processing your request",
                Status = (int)HttpStatusCode.InternalServerError,
            };

            context.Result = new ObjectResult(problemDetails);

            context.ExceptionHandled = true;
        }
    }
}
