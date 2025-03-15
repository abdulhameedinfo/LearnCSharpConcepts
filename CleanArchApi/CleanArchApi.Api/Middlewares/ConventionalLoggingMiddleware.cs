namespace CleanArchApi.CleanArchApi.Api.Middlewares;

public class ConventionalLoggingMiddleware(RequestDelegate next,  ILogger<ConventionalLoggingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        logger.LogInformation("Before the request");
        await next(httpContext);
        logger.LogInformation("After the request");
    }
}