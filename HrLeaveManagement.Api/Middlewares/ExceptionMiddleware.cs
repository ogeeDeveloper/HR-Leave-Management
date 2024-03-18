using System.Net;
using HrLeaveManagement.Api.Models;
using HRLeaveManagement.Application.Exceptions;

namespace HrLeaveManagement.Api.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        // Default status code
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        // Default problem
        dynamic problem = null;
        
        // Switch statement to determine what kind of exception we're working with
        switch (ex)
        {
            // Bad Request
            case BadRequestException badRequestException:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CustomValidationProblemDetails
                {
                    Title = badRequestException.Message,
                    Status = (int)statusCode,
                    Detail = badRequestException.InnerException?.Message,
                    Type = nameof(BadRequestException),
                    Errors = badRequestException.ValidationErrors
                };
                break;
            //Not found exception
            case NotFoundException NotFound:
                statusCode = HttpStatusCode.NotFound;
                problem = new CustomValidationProblemDetails
                {
                    Title = ex.Message,
                    Status = (int)statusCode,
                    Type = nameof(NotFoundException),
                    Detail = ex.InnerException?.Message,
                };
                break;
            default:
                problem = new CustomValidationProblemDetails
                {
                    Title = ex.Message,
                    Status = (int)statusCode,
                    Type = nameof(HttpStatusCode.InternalServerError),
                    Detail = ex.StackTrace,
                };
                break;
        }

        httpContext.Response.StatusCode = (int)statusCode;
        //await httpContext.Response.WriteAsJsonAsync(problem);
        // Only write the problem as JSON if it's initialized
        if (problem != null)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(problem);
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(json);
        }
    }
}