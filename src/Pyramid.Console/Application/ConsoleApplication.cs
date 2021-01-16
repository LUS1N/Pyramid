using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Pyramid.Console.Application.Exceptions;
using Pyramid.Console.Application.InputParser;
using Pyramid.Console.Application.Output;
using Pyramid.Solver;

namespace Pyramid.Console.Application
{
    public interface IApplication
    {
        void Run(string[] args);
    }

    public class ConsoleApplication : IApplication
    {
        private readonly ILogger<ConsoleApplication> _logger;
        private readonly IOutputWriter _outputWriter;
        private readonly IInputParser _inputParser;
        private readonly IPyramidSolver _pyramidSolver;

        public ConsoleApplication(
            ILogger<ConsoleApplication> logger,
            IOutputWriter outputWriter,
            IInputParser inputParser,
            IPyramidSolver pyramidSolver)
        {
            _logger = logger;
            _outputWriter = outputWriter;
            _inputParser = inputParser;
            _pyramidSolver = pyramidSolver;
        }

        public void Run(string[] args)
        {
            try
            {
                TryRun(args);
            }
            catch (ConsoleApplicationException e)
            {
                _outputWriter.WriteError(e.Message);
            }
        }

        private void TryRun(string[] args)
        {
            _logger.LogInformation("Running with args {@args}", args);
            var filePath = GetFilePath(args);
            var pyramidRows = _inputParser.ParsePyramid(filePath);

            var result = _pyramidSolver.Solve(pyramidRows);
            OutputResult(result);
        }

        private void OutputResult(PyramidResult result)
        {
            _logger.LogInformation("Outputting result {@res}", result);
            var path = string.Join(", ", result.Path);
            var msg = $"Max sum: {result.Sum}{Environment.NewLine}Path: {path}";
            _outputWriter.WriteMessage(msg);
        }

        private static string GetFilePath(IReadOnlyList<string> args) =>
            args.FirstOrDefault() ??
            throw new ConsoleApplicationException("File path needs to be passed as input");
    }
}