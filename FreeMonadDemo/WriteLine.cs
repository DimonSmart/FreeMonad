namespace FreeMonadDemo
{
    public class WriteLine : ICommand
    {
        public string Message { get; }
        public WriteLine(string message) { Message = message; }
    }
}