var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddJsonConsole();
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();