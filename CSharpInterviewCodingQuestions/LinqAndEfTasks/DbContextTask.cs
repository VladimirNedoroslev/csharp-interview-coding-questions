using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LinqAndEfTasks;

file class Report
{
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public byte[] ExcelContent { get; set; }
}

file class FooDbContext : DbContext
{
    public DbSet<Report> Reports { get; set; }
}

file class ReportService
{
    private readonly FooDbContext _dbContext;

    public ReportService(FooDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Report>> GetAllReportsForYear(int year)
    {
        // very long operation
        var allReports = await _dbContext.Reports
            .Where(x => x.CreatedAt.Year == year)
            .ToListAsync();
        // how to enhance it with parallelism?
        
        return allReports;
    }
}