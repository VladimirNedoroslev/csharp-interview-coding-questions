using Microsoft.EntityFrameworkCore;

namespace LinqAndEfTasks;

file class FooDbContext : DbContext
{
    public DbSet<Region> Regions { get; set; }
}

file class Country
{
    public int CountryId { get; set; }
    public int RegionId { get; set; }
    public string Name { get; set; }
    public string IsoCode { get; set; }
    public virtual Region CountryRegion { get; set; }
}

file class Region
{
    public int RegionId { get; set; }
    public string Name { get; set; }
    public int RegionManagerId { get; set; }
    public virtual RegionManager Manager { get; set; }
    public virtual ICollection<Country> Countries { get; set; }
}

file class RegionManager
{
    public int RegionManagerId { get; set; }
    public string ContactDetails { get; set; }
    public virtual ICollection<Region> Regions { get; set; }
}

file class SomeReportService
{
    private readonly FooDbContext _dbContext;

    public SomeReportService(FooDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SomeReportAsync()
    {
        var regions = await _dbContext.Regions
            .ToListAsync();
        foreach (var region in regions)
        {
            Console.WriteLine($"Manager contact details: {region.Manager.ContactDetails}");
            foreach (var country in region.Countries)
            {
            }
        }
    }
}