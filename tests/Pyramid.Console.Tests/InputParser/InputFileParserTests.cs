using System.Threading.Tasks;
using Moq.AutoMock;
using Pyramid.Console.Application.InputParser;
using Xunit;

namespace Pyramid.Console.Tests.InputParser
{
    /// <summary>
    /// Tests for <see cref="InputFileParser"/>
    /// </summary>
    public class InputFileParserTests
    {
        private string _input = "Samples/small.txt";

        private int[][] Act()
        {
            var sut = new AutoMocker().CreateInstance<InputFileParser>();
            return sut.ParsePyramid(_input);
        }

        [Fact]
        public async Task CanParseFromSampleFile()
        {
            // act
            var result = Act();

            int[][] expected =
            {
                new[] {1},
                new[] {8, 9},
                new[] {1, 5, 9},
            };

            // assert
            Assert.Equal(expected, result);
        }
    }
}