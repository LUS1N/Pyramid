using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Pyramid.Console.Application
{
    public class ConsoleApplication : IApplication
    {
        private readonly ILogger<ConsoleApplication> _logger;

        public ConsoleApplication(ILogger<ConsoleApplication> logger)
        {
            _logger = logger;
        }

        public void Run(string[] args)
        {
            _logger.LogInformation("Running with args {@args}", args);
            var filePath = GetFilePath(args);
            // parse input from file in path
            // pass input integers to pyramid
            // output results to consoles
            args.ToList().ForEach(System.Console.WriteLine);
        }

        private static string GetFilePath(IReadOnlyList<string> args) =>
            args.FirstOrDefault() ??
            throw new ArgumentException("File path needs to be passed as input");
    }
}