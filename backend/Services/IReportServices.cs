using Backend.DTOs;

namespace Backend.Services
{
    public interface IReportService
    {
        Task<IReadOnlyList<FieldReportDto>> GetReportsAsync();
        Task<FieldReportDto> CreateReportAsync(CreateFieldReportDto dto);
        Task<FieldReportDto?> GetReportByIdAsync(Guid id);
    }
}
