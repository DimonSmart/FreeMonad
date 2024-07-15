namespace FreeMonadDemo
{
    /// <summary>
    /// Represents a command to write a line to the console.
    /// </summary>
    public class WriteLine<TChainOutput> : CommandBase<Unit, TChainOutput>
    {
        public string Message { get; }

        public WriteLine(string message) { Message = message; }
    }
}