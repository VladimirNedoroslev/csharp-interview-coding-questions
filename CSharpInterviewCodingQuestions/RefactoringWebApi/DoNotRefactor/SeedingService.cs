using RefactoringWebApi.EntityFramework;
using RefactoringWebApi.Models;

namespace RefactoringWebApi.DoNotRefactor;

public class SeedingService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<SeedingService> _logger;

    public SeedingService(
        ApplicationDbContext dbContext,
        ILogger<SeedingService> logger
    )
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    private readonly List<Cat> _seededCat = new()
    {
        new Cat
        {
            Id = 1,
            Age = 3,
            Name = "Tom",
            Description = "some nice cat",
            UserId = 1
        },
        
        new Cat
        {
            Id = 2,
            Age = 7,
            Name = "George",
            Description = "Very cute and fluffy",
            UserId = 1
        },
        new Cat
        {
            Id = 3,
            Age = 1,
            Name = "Jane",
            Description = "young monster!",
            UserId = 1
        }
    };

    public void SeedData()
    {
        var catsCount = _dbContext.Cats.Count(x => x.Id < 3);
        if (catsCount > _seededCat.Count)
        {
            _logger.LogInformation("There are more than 3 cats in the db, the default one won't be seeded");
            return;

        }

        try
        {
            _dbContext.AddRange(_seededCat);
            _dbContext.SaveChanges();
            _logger.LogInformation("Default cats have been seeded successfully!");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not seed the default cats!");
        }
    }
}