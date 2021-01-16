using System.Collections.Generic;
using System.Linq;

namespace Pyramid.Solver.Builder
{
    public interface IPyramidGraphBuilder
    {
        /// <summary>
        /// Returns a list of bottom nodes that are connected to the root node of the pyramid
        /// </summary>
        public IEnumerable<IPyramidNode> BuildBottomsUpPyramidGraph();
    }

    public class PyramidGraphBuilder : IPyramidGraphBuilder
    {
        private readonly int[][] _rows;

        public PyramidGraphBuilder(int[][] rows)
        {
            _rows = rows;
        }

        public IEnumerable<IPyramidNode> BuildBottomsUpPyramidGraph() =>
            GetBottomNodes(new PyramidNode()
            {
                Value = _rows[0][0],
                Row = 0,
                Column = 0,
            });

        private IEnumerable<PyramidNode> GetBottomNodes(PyramidNode parent)
        {
            if (IsCurrentRowBottom(parent))
                return new List<PyramidNode>() {parent};

            var nodes = GetChildren(parent);

            return nodes.SelectMany(GetBottomNodes);
        }

        /// <summary>
        /// Returns children nodes for parent.
        /// Valid nodes can be directly under parent or under and to the right and reachable
        /// </summary>
        /// <param name="parent"></param>
        private IEnumerable<PyramidNode> GetChildren(PyramidNode parent)
        {
            var currentRow = parent.Row + 1;
            return new List<PyramidNode>()
                {
                    new()
                    {
                        Parent = parent,
                        Row = currentRow,
                        Column = parent.Column,
                        Value = _rows[currentRow][parent.Column]
                    },
                    new()
                    {
                        Parent = parent,
                        Row = currentRow,
                        Column = parent.Column + 1,
                        Value = _rows[currentRow][parent.Column + 1]
                    }
                }
                .Where(child => CanBeReachedFromParent(parent, child));
        }

        private static bool CanBeReachedFromParent(PyramidNode parent, PyramidNode n) =>
            IsEven(n.Value) != IsEven(parent.Value);

        private bool IsCurrentRowBottom(PyramidNode parent) => _rows.Length == parent.Row + 1;

        private static bool IsEven(int number) => number % 2 == 0;
    }
}