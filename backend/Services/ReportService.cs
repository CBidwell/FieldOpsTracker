using Backend.DTOs;

namespace Backend.Services
{
    public class ReportService : IReportService
    {
        public IEnumerable<FieldReportDto> GetReports()
        {
            return new[]
            {
                new FieldReportDto(Guid.NewGuid(), "Valve Yard 3", "Pressure anomaly", DateTime.UtcNow)
            };
        }
    }
}
