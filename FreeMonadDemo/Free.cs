namespace FreeMonadDemo
{
    public class Free<TOutput> : IFree<TOutput>
    {
        public ICommand<TOutput> Next { get; set; }
    }
}
