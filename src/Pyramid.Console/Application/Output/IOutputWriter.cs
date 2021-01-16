namespace Pyramid.Console.Application.Output
{
    public interface IOutputWriter
    {
        void WriteMessage(string message);
        void WriteError(string errorMessage);
    }
}