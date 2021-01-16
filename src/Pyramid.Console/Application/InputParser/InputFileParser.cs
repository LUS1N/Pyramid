using System;
using System.IO;
using System.Linq;

namespace Pyramid.Console.Application.InputParser
{
    public class InputFileParser : IInputParser
    {
        public int[][] ParsePyramid(string path)
        {
            var lines = GetFileContent(path);
            return lines
                .Select(ParseInts)
                .ToArray();
        }

        private static string[] GetFileContent(string path) =>
            File.Exists(path) ? File.ReadAllLines(path) : throw new ApplicationException($"File '{path}' not found");

        private static int[] ParseInts(string line) =>
            line
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
    }
}