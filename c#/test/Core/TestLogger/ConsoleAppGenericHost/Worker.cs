using Microsoft.Extensions.Logging;

namespace ConsoleAppGenericHost;

public class Worker
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    public void Execute()
    {
        _logger.LogInformation("Info Log");
        _logger.LogWarning("Warning Log");
        _logger.LogError("Error Log");
        _logger.LogCritical("Critical Log");
    }
}