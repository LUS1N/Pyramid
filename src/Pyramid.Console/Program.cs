using System;
using Microsoft.Extensions.DependencyInjection;
using Pyramid.Console.Application;

namespace Pyramid.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = BuildServiceProvider();
            var app = serviceProvider.GetRequiredService<IApplication>();
            app.Run(args);
        }

        private static IServiceProvider BuildServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            Startup.ConfigureServices(serviceCollection);
            return serviceCollection.BuildServiceProvider();
        }
    }
}