using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BuberDinner.API.Common.Filter
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var problemDetail = new ProblemDetails
            {
                Type = "https://www.rfc-editor.org/rfc/rfc7231",
                Title = "<FilterLayer> - An error occurred while processing your request!!!",
                Detail = exception.Message,
                Instance = "/auth/register",
                Status = (int)HttpStatusCode.InternalServerError,
            };

            context.Result = new ObjectResult(problemDetail);

            context.ExceptionHandled = true;
        }
    }
}
