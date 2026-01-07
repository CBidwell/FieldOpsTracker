using Backend.Services;

var builder = WebApplication.CreateBuilder(args);
var frontendOrigin = builder.Configuration["FRONTEND_ORIGIN"];
var enableSwagger = builder.Configuration["ENABLE_SWAGGER"] == "true";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IReportService, ReportService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        var origins = new List<string> { "http://localhost:5173" };
        if (!string.IsNullOrWhiteSpace(frontendOrigin))
            origins.Add(frontendOrigin);

        policy.WithOrigins(origins.ToArray())
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.Logger.LogInformation("Backend API starting up");

if (enableSwagger)
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseCors();

app.MapControllers();

app.Run();
