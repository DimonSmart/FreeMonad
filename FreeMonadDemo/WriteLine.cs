namespace FreeMonadDemo
{

    /// <summary>
    /// Represents a command to write a line to the console.
    /// </summary>
    public class WriteLine : ICommand<string, Unit>
    {
        public string Message { get; }

        public WriteLine(string message) { Message = message; }

        public override string ToString() => $"WriteLine({Message})";
    }
}