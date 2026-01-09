using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class FieldOpsDbContext : DbContext
{
    public FieldOpsDbContext(DbContextOptions<FieldOpsDbContext> options)
        : base(options) { }

    public DbSet<FieldReport> FieldReports => Set<FieldReport>();
}