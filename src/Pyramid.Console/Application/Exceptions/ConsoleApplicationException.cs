using System;

namespace Pyramid.Console.Application.Exceptions
{
    public class ConsoleApplicationException : Exception
    {
        public ConsoleApplicationException(string message) : base(message)
        {
        }
    }
}