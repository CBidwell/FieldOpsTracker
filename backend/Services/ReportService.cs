using Backend.Data;
using Backend.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class ReportService : IReportService
    {
        private readonly FieldOpsDbContext _dbContext;
        
        public ReportService(FieldOpsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<FieldReportDto>> GetReportsAsync()
        {
            return await _dbContext.FieldReports
                .OrderByDescending(r => r.CreatedUtc)
                .Select(r => new FieldReportDto(
                    r.Id,
                    r.SiteName,
                    r.Summary,
                    r.CreatedUtc
                ))
                .ToListAsync();
        }

        public async Task<FieldReportDto> CreateReportAsync(CreateFieldReportDto dto)
        {
            var entity = new Data.Entities.FieldReport
            {
                Id = Guid.NewGuid(),
                SiteName = dto.SiteName,
                Summary = dto.Summary,
                CreatedUtc = DateTime.UtcNow
            };
            
            _dbContext.FieldReports.Add(entity);
            await _dbContext.SaveChangesAsync();
            
            return new FieldReportDto(
                entity.Id,
                entity.SiteName,
                entity.Summary,
                entity.CreatedUtc
            );
        }

        public async Task<FieldReportDto?> GetReportByIdAsync(Guid id)
        {
            return await _dbContext.FieldReports
               .Where(r => r.Id == id)
               .Select(r => new FieldReportDto(
                   r.Id,
                   r.SiteName,
                   r.Summary,
                   r.CreatedUtc
               ))
               .FirstOrDefaultAsync();
        }
    }
}
