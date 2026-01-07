using Backend.DTOs;

namespace Backend.Services
{
    public interface IReportService
    {
        IEnumerable<FieldReportDto> GetReports();
    }
}
