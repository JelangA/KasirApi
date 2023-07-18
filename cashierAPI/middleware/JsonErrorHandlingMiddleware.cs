using System.Net;
using cashierAPI.src.util;
using MySqlConnector;
using Newtonsoft.Json;

namespace cashierAPI.middelware;

public class JsonErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public JsonErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Log the exception here if needed

        var statusCode = HttpStatusCode.InternalServerError;
        var message = "An unexpected error occurred.";

        if (exception is MySqlException)
        {
            statusCode = HttpStatusCode.InternalServerError;
            message = "Unable to connect to the MySQL server.";
        }
        else if (exception is InvalidOperationException)
        {
            statusCode = HttpStatusCode.InternalServerError;
            message = "A transient failure occurred while connecting to the database.";
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var errorResponse = new ResponseErr(message, exception.GetType().Name);

        var json = JsonConvert.SerializeObject(errorResponse);
        return context.Response.WriteAsync(json);
    }
}
