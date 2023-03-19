using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace Services.Utils;

public class CustomConsoleLoggerProvider : ILoggerProvider
{
    private readonly ColoredConsoleLoggerConfiguration _config;
    private readonly ConcurrentDictionary<string, CustomLogger> _loggers = new();

    public CustomConsoleLoggerProvider(ColoredConsoleLoggerConfiguration config)
    {
        _config = config;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return _loggers.GetOrAdd(categoryName, name => new CustomLogger(name, _config));
    }

    public void Dispose()
    {
        _loggers.Clear();
    }
}