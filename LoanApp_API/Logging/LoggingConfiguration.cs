using Serilog;
using Serilog.Events;

namespace LoanApp_API.Logging
{
    public static class LoggingConfiguration
    {
        public static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("logs/loanapp-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
