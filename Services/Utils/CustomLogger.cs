using Microsoft.Extensions.Logging;

namespace Services.Utils;

public class ColoredConsoleLoggerConfiguration
{
    public LogLevel LogLevel { get; set; } = LogLevel.Warning;
    public int EventId { get; set; } = 0;
    public ConsoleColor Color { get; set; } = ConsoleColor.Yellow;
}

public class CustomLogger : ILogger
{
    private readonly ColoredConsoleLoggerConfiguration _config;
    private readonly string _name;

    public CustomLogger(string name, ColoredConsoleLoggerConfiguration config)
    {
        _name = name;
        _config = config;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel == _config.LogLevel;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
        Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;

        if (_config.EventId == 0 || _config.EventId == eventId.Id)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = _config.Color;
            Console.WriteLine($"{_name} {logLevel.ToString().ToUpper()} - {formatter(state, exception)}");
            Console.ForegroundColor = color;
        }
    }
}