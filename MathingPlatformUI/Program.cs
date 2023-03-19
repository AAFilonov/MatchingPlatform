using Services.impl;
using Services.@interface;
using Services.Utils;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllersWithViews();
    builder.Services.AddCors();

    builder.Services.AddScoped<IFileParsingService, FileParsingService>();
    builder.Services.AddScoped<IMatchingExecutionService, MatchingExecutionService>();
    builder.Services.AddScoped<IImportMatchingService, ImportMatchingService>();


    builder.Logging.AddDebug();
    builder.Logging.AddProvider(new CustomConsoleLoggerProvider(new ColoredConsoleLoggerConfiguration
    {
        LogLevel = LogLevel.Information,
        EventId = 1,
        Color = ConsoleColor.Green
    }));
    builder.Logging.AddProvider(new CustomConsoleLoggerProvider(new ColoredConsoleLoggerConfiguration
    {
        LogLevel = LogLevel.Error,
        EventId = 1,
        Color = ConsoleColor.Red
    }));
    builder.Logging.AddProvider(new CustomConsoleLoggerProvider(new ColoredConsoleLoggerConfiguration
    {
        LogLevel = LogLevel.Debug,
        EventId = 1,
        Color = ConsoleColor.Gray
    }));
}

var app = builder.Build();
// Configure the HTTP request pipeline.
//TODO настроить запуск продоволго сервера
if (!app.Environment.IsDevelopment())
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

app.UseStaticFiles();
app.UseRouting();

app.UseCors(policyBuilder => policyBuilder
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowAnyOrigin()
);
app.UseHttpsRedirection();
app.MapControllers();

app.MapFallbackToFile("index.html");
app.UseMiddleware<ErrorHandlerMiddleware>();


app.Run();