namespace FreeMonadDemo
{
    public abstract class CommandBase<TCommandOutput, TChainOutput> : ICommand<TChainOutput>
    {
        public Func<TCommandOutput, IFree<TChainOutput>> NextF { get; set; }
    }
}