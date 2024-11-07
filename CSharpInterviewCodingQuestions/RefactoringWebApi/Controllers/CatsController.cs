using Microsoft.AspNetCore.Mvc;
using RefactoringWebApi.Dtos;
using RefactoringWebApi.EntityFramework;
using RefactoringWebApi.Models;
using RefactoringWebApi.Services;

namespace RefactoringWebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CatsController : Controller
{
    private ApplicationDbContext _dbContext;
    private EmailService _emailService;
    private ILogger<CatsController> _logger;

    public CatsController(
        ApplicationDbContext dbContext,
        EmailService emailService,
        ILogger<CatsController> logger
    )
    {
        _dbContext = dbContext;
        _emailService = emailService;
        _logger = logger;
    }


    [HttpGet]
    public IActionResult GetCats()
    {
        return Ok(_dbContext.Cats.ToList());
    }

    [HttpGet]
    public IActionResult GetCat([FromQuery] int id)
    {
        return Ok(_dbContext.Cats.SingleOrDefault(x => x.Id == id));
    }

    [HttpPost]
    public async Task<IActionResult> AddCat(Cat cat)
    {
        await _dbContext.Cats.AddAsync(cat);
        await _dbContext.SaveChangesAsync();
        await _emailService.NotifyAdmin(cat);
        _logger.LogInformation($"A new cat {cat.Name} has been created!");
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> ChangeCat([FromBody] ChangeCatDto changeCatDto)
    {
        var cat = _dbContext.Cats.Single(x => x.Id == changeCatDto.Id);
        cat.Description = changeCatDto.Description;
        cat.Name = changeCatDto.Name;
        cat.Age = changeCatDto.Age;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> ChangeCatsDescription([FromBody] ChangeCatDto changeCatDto)
    {
        var cat = _dbContext.Cats.Single(x => x.Id == changeCatDto.Id);
        cat.Description = changeCatDto.Description;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveCat([FromQuery] int id)
    {
        var cat = _dbContext.Cats.Single(x => x.Id == id);
        _dbContext.Remove(cat);
        _logger.LogInformation($"Cat {cat.Id} has been removed!");
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}