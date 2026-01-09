using Backend.Data;
using Backend.Data.Entities;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddDbContext<FieldOpsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<FieldOpsDbContext>();

    if (!db.FieldReports.Any())
    {
        db.FieldReports.AddRange(
            new FieldReport
            {
                Id = Guid.NewGuid(),
                SiteName = "North Pasture",
                Summary = "Hay delivered",
                CreatedUtc = DateTime.UtcNow
            },
            new FieldReport
            {
                Id = Guid.NewGuid(),
                SiteName = "Barn",
                Summary = "Fence check complete",
                CreatedUtc = DateTime.UtcNow
            }
        );

        db.SaveChanges();
    }
}


app.UseCors();

app.MapControllers();

app.Run();
