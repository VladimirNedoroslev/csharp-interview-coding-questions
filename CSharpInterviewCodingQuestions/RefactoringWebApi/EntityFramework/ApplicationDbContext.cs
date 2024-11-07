using Microsoft.EntityFrameworkCore;
using RefactoringWebApi.Models;

namespace RefactoringWebApi.EntityFramework;

// no need to refactor
public class ApplicationDbContext : DbContext

{
    
    
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Cat> Cats { get; set; }
    public DbSet<User> Users { get; set; }
}