using System.IO;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Pyramid.Solver;
using Xunit;

namespace Pyramid.Tests
{
    public class ComponentTests
    {
        IPyramidSolver MakeSut() =>
            new ServiceCollection()
                .AddPyramidSolver()
                .BuildServiceProvider()
                .GetRequiredService<IPyramidSolver>();

        [Fact]
        public void SolvesSmallPyramid()
        {
            // arrange
            int[][] input =
            {
                new[] {1},
                new[] {8, 9},
                new[] {1, 5, 9},
                new[] {4, 5, 2, 3},
            };

            var sut = MakeSut();

            // act
            var result = sut.Solve(input);

            // assert
            result.Sum.Should().Be(16);
            result.Path.Should().Equal(1, 8, 5, 2);
        }

        [Fact]
        public void SolvesBigPyramid()
        {
            // arrange
            var input = JsonConvert.DeserializeObject<int[][]>(File.ReadAllText("Payloads/Big.json"));

            var sut = MakeSut();

            // act
            var result = sut.Solve(input);

            // assert
            result.Sum.Should().Be(8186);
            result.Path.Should().Equal(215, 192, 269, 836, 805, 728, 433, 528, 863, 632, 931, 778, 413, 310, 253);
        }
    }
}