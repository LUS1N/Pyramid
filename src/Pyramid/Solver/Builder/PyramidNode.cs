using System.Linq;

namespace Pyramid.Solver.Builder
{
    public interface IPyramidNode
    {
        public int Value { get; }
        public PyramidNode Parent { get; }
        public PyramidResult GetPyramidResult();
    }

    public class PyramidNode : IPyramidNode
    {
        public int Value { get; init; }
        public PyramidNode Parent { get; init; }
        public int Row { get; init; }
        public int Column { get; init; }

        public PyramidResult GetPyramidResult()
        {
            if (Parent is null)
                return new PyramidResult()
                {
                    Path = new[] {Value},
                    Sum = Value
                };

            var parentResult = Parent.GetPyramidResult();
            return new PyramidResult()
            {
                Path = parentResult.Path.Append(Value).ToArray(),
                Sum = Value + parentResult.Sum
            };
        }
    }
}