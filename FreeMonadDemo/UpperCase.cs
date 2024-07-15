namespace FreeMonadDemo
{
    /// <summary>
    /// Represents a command to convert a string to uppercase.
    /// </summary>
    public class UpperCase<TChainOutput> : CommandBase<string, TChainOutput>
    {
        public string Input { get; }

        public UpperCase(string input)
        {
            Input = input;
        }
    }
}
