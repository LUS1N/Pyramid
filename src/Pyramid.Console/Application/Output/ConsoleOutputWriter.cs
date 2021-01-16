namespace Pyramid.Console.Application.Output
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void WriteMessage(string message)
        {
            System.Console.WriteLine(message);
        }

        public void WriteError(string errorMessage)
        {
            System.Console.Error.Write(errorMessage);
        }
    }
}