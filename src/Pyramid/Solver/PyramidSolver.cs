using System.Linq;
using Pyramid.Solver.Builder.Factory;

namespace Pyramid.Solver
{
    public interface IPyramidSolver
    {
        PyramidResult Solve(int[][] rows);
    }

    public class PyramidSolver : IPyramidSolver
    {
        private readonly IPyramidGraphBuilderFactory _builderFactory;

        public PyramidSolver(IPyramidGraphBuilderFactory builderFactory)
        {
            _builderFactory = builderFactory;
        }

        public PyramidResult Solve(int[][] rows)
        {
            var builder = _builderFactory.Create(rows);
            var bottomNodes = builder.BuildBottomsUpPyramidGraph();

            return bottomNodes
                .Select(p => p.GetPyramidResult())
                .OrderByDescending(r => r.Sum)
                .First();
        }
    }
}