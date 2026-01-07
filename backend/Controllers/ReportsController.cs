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
        public ActionResult<IEnumerable<FieldReportDto>> Get()
        {
            _logger.LogInformation("Fetching all field reports.");
            var reports = _service.GetReports();
            return Ok(reports);
        }
    }

}
