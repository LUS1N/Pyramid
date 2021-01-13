using System.Collections.Generic;

namespace Pyramid.Console.InputParser
{
    public interface IInputParser
    {
        List<List<int>> ParsePyramid(string[] args);
    }
}