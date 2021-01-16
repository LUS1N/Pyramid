using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pyramid.Console.Application;
using Pyramid.Console.Application.InputParser;
using Serilog;

namespace Pyramid.Console
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddPyramidLogging();
            services.AddPyramidSolver();

            services.AddTransient<IApplication, ConsoleApplication>();
            services.AddTransient<IInputParser, InputFileParser>();
        }

        private static IServiceCollection AddPyramidLogging(this IServiceCollection services)
        {
#if DEBUG
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            services.AddSingleton(new LoggerFactory().AddSerilog());
#endif
            services.AddLogging();
            return services;
        }
    }
}