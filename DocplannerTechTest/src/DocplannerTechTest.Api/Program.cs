using DocplannerTechTest.Api.Extensions;
using DocplannerTechTest.Api.Middlewares;
using DocplannerTechTest.Application.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

// Load environment-specific appsettings.json
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

// Bind configuration
builder.Services.Configure<ServiceUrlsConfig>(builder.Configuration.GetSection("ServiceUrls"));
builder.Services.Configure<AuthenticationConfig>(builder.Configuration.GetSection("Authentication"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();