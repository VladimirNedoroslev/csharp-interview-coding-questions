using RefactoringWebApi.Models;

namespace RefactoringWebApi.Services;

public class EmailService
{
    private IConfiguration _configuration;
    private ILogger<EmailService> _logger;

    public EmailService(
        IConfiguration configuration,
        ILogger<EmailService> logger)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public Task NotifyAdmin(Cat cat)
    {
        var adminEmail = _configuration.GetSection("AdminEmail").Get<string>();
        _logger.LogInformation($"Email has been sent to the admin - {adminEmail} about a new cat {cat.Name}");

        // code to send to the real SMTP
        return Task.CompletedTask;
    }
}