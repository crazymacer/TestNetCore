using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            var exception = context.Exception;
            var validation = new
            {
                Status = 500,
                Title = "Internal Server Error",
                Detail = exception.Message
            };

            context.Result = new BadRequestObjectResult(validation);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.ExceptionHandled = true;

        }
    }
}
