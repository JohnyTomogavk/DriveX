using Serilog;

namespace DriveX.API.Config;

public static class AppLoggerConfig
{
    public static IServiceCollection ConfigureSerilog(this IServiceCollection services)
    {
        return services.AddSerilog(
            (ctx, cfg) =>
            {
                var logMessagetemplate = "{RequestId} {CorrelationId} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

                cfg.MinimumLevel.Debug()
                    .Enrich.FromLogContext();

                cfg.WriteTo.Console(outputTemplate: logMessagetemplate);

                cfg.WriteTo.File(
                    "logs/api-log-.log",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true,
                    outputTemplate: logMessagetemplate);
            });
    }
}