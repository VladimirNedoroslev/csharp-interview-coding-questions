using Microsoft.EntityFrameworkCore;

namespace LinqAndEfTasks;

public class FooDbContext : DbContext
{
    public DbSet<Person> People { get; set; }
}

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }

    public bool IsActive { get; set; }
}

public static class EfTask
{
    public static void Start()
    {
    }

    // What is the difference between these methods?

    private static IEnumerable<Person> GetActivePeople1(FooDbContext dbContext)
    {
        return dbContext.People
            .Where(x => x.IsActive)
            .ToList();
    }

    private static IEnumerable<Person> GetActivePeople2(FooDbContext dbContext)
    {
        return dbContext.People
            .ToList()
            .Where(x => x.IsActive);
    }
}