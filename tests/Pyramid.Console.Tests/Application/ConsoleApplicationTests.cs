using System;
using System.Linq;
using Moq;
using Moq.AutoMock;
using Pyramid.Console.Application;
using Pyramid.Console.Application.Exceptions;
using Pyramid.Console.Application.InputParser;
using Pyramid.Console.Application.Output;
using Pyramid.Solver;
using Xunit;

namespace Pyramid.Console.Tests.Application
{
    /// <summary>
    /// Tests for <see cref="ConsoleApplication"/>
    /// </summary>
    public class ConsoleApplicationTests
    {
        private string[] _input = {"file.txt"};
        private readonly AutoMocker _mocker = new();
        private readonly int[][] _parsedPyramid = {new[] {1}};

        public ConsoleApplicationTests()
        {
            // happy path setups
            _mocker.Use<IInputParser>(m => m.ParsePyramid(_input.First()) == _parsedPyramid);
        }

        private void Act()
        {
            var application = _mocker.CreateInstance<ConsoleApplication>();
            application.Run(_input);
        }

        [Fact]
        public void NoArgumentsPassed_WritesError()
        {
            // arrange
            _input = new string[0];

            // act
            Act();

            // assert
            _mocker
                .GetMock<IOutputWriter>()
                .Verify(x =>
                    x.WriteError("File path needs to be passed as input"));
        }

        [Fact]
        public void InputParserThrows_WritesErrorMessage()
        {
            // arrange
            var parserMock = new Mock<IInputParser>();
            var message = "error message!";
            parserMock.Setup(parser =>
                    parser.ParsePyramid(_input.First()))
                .Throws(new ConsoleApplicationException(message));

            _mocker.Use(parserMock);

            // act
            Act();

            // assert
            _mocker
                .GetMock<IOutputWriter>()
                .Verify(x =>
                    x.WriteError(message));
        }

        [Fact]
        public void OutputsSolvedPyramidMessage()
        {
            // arrange
            var result = new PyramidResult()
            {
                Path = new[] {1, 2, 3,},
                Sum = 6
            };

            _mocker.Use<IPyramidSolver>(x => x.Solve(_parsedPyramid) == result);

            // act
            Act();

            // assert
            var expectedOutput = $"Max sum: 6{Environment.NewLine}Path: 1, 2, 3";

            _mocker.GetMock<IOutputWriter>()
                .Verify(x => x.WriteMessage(expectedOutput));
        }
    }
}