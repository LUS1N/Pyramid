using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using Pyramid.Solver;
using Pyramid.Solver.Builder;
using Pyramid.Solver.Builder.Factory;
using Xunit;

namespace Pyramid.Tests
{
    /// <summary>
    /// Tests for <see cref="PyramidSolver"/>
    /// </summary>
    public class PyramidSolverTests
    {
        private readonly AutoMocker _mocker = new();
        private int[][] _input = { };
        private List<IPyramidNode> _bottomNodes = new();

        public PyramidSolverTests()
        {
            var graphBuilderMock =
                Mock.Of<IPyramidGraphBuilder>(x =>
                    x.BuildBottomsUpPyramidGraph() == _bottomNodes);

            _mocker.Use<IPyramidGraphBuilderFactory>(m => m.Create(_input) == graphBuilderMock);
        }

        private PyramidResult Act()
        {
            var sut = (IPyramidSolver) _mocker.CreateInstance<PyramidSolver>();
            return sut.Solve(_input);
        }

        [Fact]
        public void ReturnsHighestValueResult()
        {
            // arrange
            var smaller = new PyramidResult()
            {
                Path = new[] {1, 2, 3},
                Sum = 6
            };

            var bigger = new PyramidResult()
            {
                Path = new[] {3, 2, 3},
                Sum = 8
            };

            _bottomNodes.Add(Mock.Of<IPyramidNode>(x => x.GetPyramidResult() == bigger));
            _bottomNodes.Add(Mock.Of<IPyramidNode>(x => x.GetPyramidResult() == smaller));

            // act
            var result = Act();

            // assert
            result.Should().Be(bigger);
        }
    }
}