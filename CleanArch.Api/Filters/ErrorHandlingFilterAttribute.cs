using System.Net;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArch.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        var code = HttpStatusCode.InternalServerError;

        context.Result = new ObjectResult(new 
        {
            code = code,
            error = "An unexpected error occurred.",
            message = exception.Message
        });

        context.ExceptionHandled = true;
    }
}