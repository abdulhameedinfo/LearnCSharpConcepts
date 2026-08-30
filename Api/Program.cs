using System.Text;
using Api.CleanArchApi.Api.Middlewares;
using Application;
using Application.Interfaces.Idempotency;
using Application.Interfaces;
using Application.Products.Create;
using Application.Services;
using CleanArchApi.Infrastructure;
using Domain.Interfaces;
using CleanArchApi.Infrastructure.Persistance;
using CleanArchApi.Infrastructure.Repository;
using CleanArchApi.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); 
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddTransient<FactoryMiddleware>(); // Register Factory based middleware
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

RequestDelegateMiddleware(app);  // Request delegaate bases
app.UseMiddleware<ConventionalLoggingMiddleware>(); // Conventional based logging middleware

app.UseMiddleware<FactoryMiddleware>(); // Factory based logging middleware 

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");

app.MapPost("/products", async (
    CreateProductRequest request,
    [FromHeader(Name = "X-Idempotency-Key")]
    string requestId,
    ISender sender) =>
{
    if (!Guid.TryParse(requestId, out Guid parsedRequestId))
    {
        return Results.BadRequest("Invalid Idempotency Key");
    }

    var command = new CreateProductCommand(parsedRequestId, request.Name, request.Price, request.Sku);

    try
    {
        await sender.Send(command);
        return Results.Ok();
    }
    catch (IdempotentRequestAlreadyExistsException ex)
    {
        return Results.Conflict(ex.Message);
    }
});

app.MapControllers(); 
app.Run();

void RequestDelegateMiddleware(WebApplication webApplication)
{
    webApplication.Use(async (context, next) =>
    {
        Console.WriteLine("Request executing...");
        await next(context);
        Console.WriteLine("Requestt executed!");
    });
}

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
