namespace FreeMonadDemo
{
    public abstract class BaseInterpreter
    {
        public T Interpret<T>(IFree<T> operation)
        {
            switch (operation)
            {
                case Free<T> free:
                    return InterpretCommand(free.Next);

                case Pure<T> pure:
                    PostInterpret();
                    return pure.Value;

                default:
                    throw new InvalidOperationException("Unsupported operation type");
            }
        }

        public abstract T InterpretCommand<T>(ICommand<T> command);

        protected virtual void PostInterpret()
        {
        }
    }
}