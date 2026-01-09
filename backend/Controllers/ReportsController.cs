using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _service;
        private readonly ILogger<ReportsController> _logger;

        public ReportsController(IReportService service, ILogger<ReportsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<FieldReportDto>>> GetReportsAsync()
        {
            _logger.LogInformation("Fetching all field reports.");
            var reports = await _service.GetReportsAsync();
            return Ok(reports);
        }

        [HttpGet("{id:guid}", Name = "GetReportById")]
        public async Task<ActionResult<FieldReportDto>> GetReportByIdAsync(Guid id)
        {
            var report = await _service.GetReportByIdAsync(id);
            return report is null ? NotFound() : Ok(report);
        }

        [HttpPost]
        public async Task<ActionResult<FieldReportDto>> CreateReportAsync(
            [FromBody] CreateFieldReportDto dto,
            [FromServices] IWebHostEnvironment env)
        {
            // TEMP: Disable writes in production until auth is implemented
            if (env.IsProduction())
            {
                _logger.LogWarning("CreateReport attempted in production");
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    "Write operations disabled in production");
            }

            if (string.IsNullOrWhiteSpace(dto.SiteName) || string.IsNullOrWhiteSpace(dto.Summary))
            {
                _logger.LogWarning("Invalid field report data received.");
                return BadRequest("SiteName and Summary are required.");
            }

            _logger.LogInformation("Creating a new field report for site: {SiteName}", dto.SiteName);
            
            var createdReport = await _service.CreateReportAsync(dto);
            
            return CreatedAtAction(
                "GetReportById",
                new { id = createdReport.Id },
                createdReport);
        }
    }

}
