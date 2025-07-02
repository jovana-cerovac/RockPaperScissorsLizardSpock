using System.Net;
using System.Text.Json;
using GameAPI.Core.Exceptions;

namespace GameAPI.Api.Middlewares;

public class ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, logger);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger logger)
    {
        HttpStatusCode status;
        string message;

        switch (exception)
        {
            case NotFoundException:
                status = HttpStatusCode.NotFound;
                message = exception.Message;
                break;

            case BadRequestException:
                status = HttpStatusCode.BadRequest;
                message = exception.Message;
                break;

            default:
                status = HttpStatusCode.InternalServerError;
                message = "An unexpected error occurred.";
                logger.LogError(exception, "Unhandled exception");
                break;
        }

        var result = JsonSerializer.Serialize(new { error = message });

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;

        return context.Response.WriteAsync(result);
    }
}