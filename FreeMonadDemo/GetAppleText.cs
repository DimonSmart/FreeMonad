namespace FreeMonadDemo
{
    /// <summary>
    /// Represents a command to get the text. For example "Apple".
    /// </summary>
    public class GetAppleText : ICommand<Unit, string>
    {
        public const string Text = "Apple";

        public GetAppleText() { }
    }
}