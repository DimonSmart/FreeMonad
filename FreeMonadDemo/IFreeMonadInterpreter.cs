namespace FreeMonadDemo
{
    public interface IFreeMonadInterpreter
    {
        void Interpret(FreeMonad<ICommand> program);
    }
}