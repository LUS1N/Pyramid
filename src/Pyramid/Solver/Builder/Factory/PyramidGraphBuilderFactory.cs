namespace Pyramid.Solver.Builder.Factory
{
    public interface IPyramidGraphBuilderFactory
    {
        IPyramidGraphBuilder Create(int[][] rows);
    }

    public class PyramidGraphBuilderFactory : IPyramidGraphBuilderFactory
    {
        public IPyramidGraphBuilder Create(int[][] rows) => new PyramidGraphBuilder(rows);
    }
}