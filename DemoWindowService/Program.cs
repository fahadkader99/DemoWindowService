using DemoWindowService;
using Serilog;

var builder = Host.CreateApplicationBuilder(args);

// Resigter MyLogic class as Singelton
builder.Services.AddSingleton<MyLogic>();

builder.Services.AddHostedService<Worker>();

// Log to a text file, interval each day - new text file & console
// When it is registered as a window service  & we use relative path, it will write to path - C:\Windows\System32\Logs
// Recommended to use Absolute path related to the project. Once it is published with Absolute path, then it will write to - C:\Users\fahad\Development\DemoWindowService\DemoWindowService\bin\Release\net8.0\publish\win-x64\logs

Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
    .WriteTo.Console()                      
    .WriteTo.File("logs/DemoAppLog.txt", rollingInterval: RollingInterval.Day)                                              // Relative path
    .WriteTo.File(AppDomain.CurrentDomain.BaseDirectory + "logs/DemoAppLog.txt", rollingInterval: RollingInterval.Day)      // Absolute path
    .CreateLogger();

// Add the logger in our service
builder.Logging.Services.AddSerilog();

// Configure this worker service app to act as window service - pass the ServiceName
builder.Services.AddWindowsService(options =>
{
    options.ServiceName = ".Net Demo Window Service";
});

var host = builder.Build();
host.Run();
