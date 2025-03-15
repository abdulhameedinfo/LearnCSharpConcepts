namespace CleanArchApi.Api.CleanArchApi.Api.Middlewares;

public class FactoryMiddleware(ILogger<FactoryMiddleware> logger): IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        logger.LogInformation("Before the request (FactoryMiddleware)");
        await  next(context);
        logger.LogInformation("After the request (FactoryMiddleware)");
    }
}