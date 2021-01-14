using System.Threading.Tasks;
using Moq.AutoMock;
using Pyramid.Console.InputParser;
using Xunit;

namespace Pyramid.Console.Tests.InputParser
{
    /// <summary>
    /// Tests for <see cref="InputFileParser"/>
    /// </summary>
    public class InputFileParserTests
    {
        private static int[][] Act(string path)
        {
            var sut = new AutoMocker().CreateInstance<InputFileParser>();
            return sut.ParsePyramid(path);
        }

        [Fact]
        public async Task CanParseFromSampleFile()
        {
            // act
            var result = Act("Samples/small.txt");

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