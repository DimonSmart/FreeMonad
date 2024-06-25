namespace FreeMonadDemo
{
    /// <summary>
    /// Represents a command to convert a string to uppercase.
    /// </summary>
    public class UpperCase : ICommand<string, string>
    {
        public string Input { get; }

        public UpperCase(string input) { Input = input; }

        public override string ToString() => $"UpperCase({Input})";
    }
}