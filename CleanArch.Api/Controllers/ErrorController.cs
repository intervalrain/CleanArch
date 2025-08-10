using CleanArch.Application.Common.Errors;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/error")]   
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
        };

        return Problem(
            statusCode: statusCode,
            detail: message
        );
    }
}