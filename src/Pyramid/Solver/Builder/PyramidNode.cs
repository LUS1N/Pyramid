namespace Pyramid.Solver.Builder
{
    public class PyramidNode
    {
        public int Value { get; init; }
        public PyramidNode Parent { get; init; }
        public int Row { get; init; }
        public int Column { get; init; }
    }
}