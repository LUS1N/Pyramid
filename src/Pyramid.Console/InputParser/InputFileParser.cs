using System.IO;
using System.Linq;

namespace Pyramid.Console.InputParser
{
    public class InputFileParser : IInputParser
    {
        public int[][] ParsePyramid(string path)
        {
            var lines = File.ReadAllLines(path);
            return lines
                .Select(ParseInts)
                .ToArray();
        }

        private static int[] ParseInts(string line) =>
            line
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
    }
}