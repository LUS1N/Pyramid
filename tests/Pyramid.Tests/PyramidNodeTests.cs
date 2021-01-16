using FluentAssertions;
using Pyramid.Solver.Builder;
using Xunit;

namespace Pyramid.Tests
{
    /// <summary>
    /// Tests for <see cref="PyramidNode"/>
    /// </summary>
    public class PyramidNodeTests
    {
        [Fact]
        public void CreatesPyramidResult_FromParentChain()
        {
            // arrange
            var node = new PyramidNode()
            {
                Value = 1,
                Parent = new PyramidNode()
                {
                    Value = 4,
                    Parent = new PyramidNode()
                    {
                        Value = 6
                    }
                }
            };

            // act
            var result = node.GetPyramidResult();

            // assert
            result.Sum.Should().Be(11);
            result.Path.Should().Equal(6, 4, 1);
        }
    }
}