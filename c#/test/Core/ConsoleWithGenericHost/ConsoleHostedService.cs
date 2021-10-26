using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsoleWithGenericHost
{
    public class ConsoleHostedService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IWeatherService _weatherService;
        private int? _exitCode;

        public ConsoleHostedService(
            ILogger<ConsoleHostedService> logger,
            IHostApplicationLifetime appLifetime,
            IWeatherService weatherService)
        {
            _logger = logger;
            _appLifetime = appLifetime;
            _weatherService = weatherService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            string message = $"ConsoleHostedService.StartAsync(): Starting with arguments: {string.Join(" ", Environment.GetCommandLineArgs())}";
            Debug.WriteLine(message);
            _logger.LogDebug(message);

            _appLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run(async () =>
                {
                    try
                    {
                        IReadOnlyList<int> temperatures = await _weatherService.GetFiveDayTemperaturesAsync();
                        for (int i = 0; i < temperatures.Count; i++)
                        {
                            _logger.LogInformation($"{DateTime.Today.AddDays(i).DayOfWeek}: {temperatures[i]}");
                        }

                        _exitCode = 0;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Unhandled exception!");
                        _exitCode = -1;
                    }
                    finally
                    {
                        _appLifetime.StopApplication();
                    }
                });
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            string message = $"ConsoleHostedService.StopAsync(): Exiting with return code: {_exitCode}";
            Debug.WriteLine(message);
            _logger.LogDebug(message);
            Environment.ExitCode = _exitCode.GetValueOrDefault(-1);

            return Task.CompletedTask;
        }
    }
}
