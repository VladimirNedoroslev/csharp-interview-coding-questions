using Microsoft.EntityFrameworkCore;
using RefactoringWebApi;
using RefactoringWebApi.DoNotRefactor;
using RefactoringWebApi.EntityFramework;
using RefactoringWebApi.Models;
using RefactoringWebApi.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddScoped<EmailService>();
services.AddDbContext<ApplicationDbContext>(o => o.UseSqlite("Data Source=Application.db"));
services.AddControllers();
services.AddScoped<SeedingService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var scope = app.Services.CreateScope();

var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
dbContext.Database.Migrate();

var configuration = app.Configuration;

var adminUser = dbContext.Users.SingleOrDefault(x => x.Id == Constants.AdminUserId);
if (adminUser == null)
{
    var adminEmail = configuration.GetSection("AdminEmail").Get<string>();
    dbContext.Users.Add(new User()
    {
        Id = Constants.AdminUserId,
        Email = adminEmail,
        Name = "Admin",
        Role = "Admin"
    });
    dbContext.SaveChanges();
}

scope.ServiceProvider.GetRequiredService<SeedingService>().SeedData();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();