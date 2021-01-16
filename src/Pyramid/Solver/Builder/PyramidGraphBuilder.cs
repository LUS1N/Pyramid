using System.Collections.Generic;
using System.Linq;

namespace Pyramid.Solver.Builder
{
    public interface IPyramidGraphBuilder
    {
        /// <summary>
        /// Returns a list of bottom nodes that are connected to the root node of the pyramid
        /// </summary>
        /// <returns></returns>
        public ICollection<PyramidNode> BuildBottomsUpPyramidGraph();
    }

    public class PyramidGraphBuilder : IPyramidGraphBuilder
    {
        private readonly int[][] _rows;

        public PyramidGraphBuilder(int[][] rows)
        {
            _rows = rows;
        }

        public ICollection<PyramidNode> BuildBottomsUpPyramidGraph() =>
            GetBottomNodes(new PyramidNode()
            {
                Value = _rows[0][0],
                Row = 0,
                Column = 0,
            });

        private List<PyramidNode> GetBottomNodes(PyramidNode parent)
        {
            var currentRow = parent.Row + 1;
            if (_rows.Length == currentRow)
                return new List<PyramidNode>() {parent};

            var nodes =
                GetCurrentLevelChildrenForParent(parent, currentRow)
                    .Where(n => CanBeReachedFromParent(parent, n));

            return nodes.SelectMany(GetBottomNodes).ToList();
        }

        private static bool CanBeReachedFromParent(PyramidNode parent, PyramidNode n) =>
            IsEven(n.Value) == !IsEven(parent.Value);


        private List<PyramidNode> GetCurrentLevelChildrenForParent(PyramidNode parent, int currentRow) =>
            new()
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
            };

        private static bool IsEven(int number) => number % 2 == 0;
    }
}