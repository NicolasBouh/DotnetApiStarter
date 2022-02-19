using System.Net;
using System.Text.Json;
using DotnetApiStarter.Application.Core.Exceptions;

namespace DotnetApiStarter.Api.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext, IWebHostEnvironment env)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExcpetionAsync(httpContext, exception);
        }
    }

    private async Task HandleExcpetionAsync(HttpContext context, Exception exception)
    {
        var errorCode = string.Empty;
        var statusCode = HttpStatusCode.InternalServerError;
        var errors = new Dictionary<string, string[]>();

        switch (exception)
        {
            case UnauthorizedAccessException unauthorizedAccessException:
                statusCode = HttpStatusCode.Unauthorized;
                errorCode = unauthorizedAccessException.Message;
                break;

            case AppException appException:
                statusCode = HttpStatusCode.BadRequest;
                errorCode = appException.ExceptionCode.ToString();
                break;
            case RequestValidationException requestValidationException:
                statusCode = HttpStatusCode.Conflict;
                errorCode = requestValidationException.Message;
                errors = requestValidationException.Errors as Dictionary<string, string[]>;
                break;
            default: 
                statusCode = HttpStatusCode.InternalServerError;
                errorCode = exception.Message;
                break;
        }

        context.Response.StatusCode = (int)statusCode;

        if (!string.IsNullOrWhiteSpace(errorCode))
        {
            var response = new { code = errorCode, message = exception.Message, errors = errors };
            var payload = JsonSerializer.Serialize(response);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(payload);
        }
    }
}