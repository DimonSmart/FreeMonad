namespace FreeMonadDemo
{
    /// <summary>
    /// Represents a command to get the text. For example "Apple".
    /// </summary>
    public class GetText<TChainOutput> : CommandBase<string, TChainOutput>
    {
        public string Text;

        public GetText(string val) { Text = val; }
    }
}