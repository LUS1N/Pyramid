using System.Linq;
using FluentAssertions;
using Pyramid.Solver.Builder;
using Xunit;

namespace Pyramid.Tests
{
    /// <summary>
    /// Tests for <see cref="PyramidGraphBuilder"/>
    /// </summary>
    public class PyramidGraphBuilderTests
    {
        private readonly int[][] _input =
        {
            new[] {1},
            new[] {8, 9},
            new[] {1, 5, 9},
        };

        [Fact]
        public void Build_Contains_BothValidBottomNodes()
        {
            // act
            var result = new PyramidGraphBuilder(_input).BuildBottomsUpPyramidGraph();

            // assert
            result.Should().Contain(n => n.Value == 1);
            result.Should().Contain(n => n.Value == 5);
            result.Should().HaveCount(2);
        }

        [Fact]
        public void Build_Holds_ParentRefChain()
        {
            // act
            var result = new PyramidGraphBuilder(_input).BuildBottomsUpPyramidGraph();

            // assert
            var n1 = result.First(n => n.Value == 1);
            n1.Parent.Value.Should().Be(8);
            n1.Parent.Parent.Value.Should().Be(1);

            var n2 = result.First(n => n.Value == 5);
            n2.Parent.Value.Should().Be(8);
            n2.Parent.Parent.Value.Should().Be(1);
        }
    }
}