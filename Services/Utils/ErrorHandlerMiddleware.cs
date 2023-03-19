using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Services.Utils;

public class ErrorHandlerMiddleware
{
    private readonly ILogger<ErrorHandlerMiddleware> _logger;
    private readonly RequestDelegate _next;


    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            switch (error)
            {
                case AppException e:
                    // custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException e:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            _logger.Log(LogLevel.Error,1, error.Message);
            _logger.Log(LogLevel.Error,1, error.Source);
            _logger.Log(LogLevel.Debug, 1,error.StackTrace);
            var result = JsonSerializer.Serialize(new { message = error?.Message });
            await response.WriteAsync(result);
        }
    }
}