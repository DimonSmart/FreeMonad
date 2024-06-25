namespace FreeMonadDemo
{
    public class FreeMonad<C, TInput, TOutput> where C : ICommand<TInput, TOutput>
    {
        public C Command { get; private set; }
        public Func<object, FreeMonad<C, TInput, TOutput>> Next { get; private set; }
        public TOutput Value { get; private set; }

        public FreeMonad(C command, Func<object, FreeMonad<C, TInput, TOutput>> next)
        {
            Command = command;
            Next = next;
        }

        private FreeMonad(TOutput value)
        {
            Value = value;
            Command = default;
            Next = _ => null;
        }

        public static FreeMonad<C, TInput, TOutput> Return(TOutput value)
        {
            return new FreeMonad<C, TInput, TOutput>(value);
        }

        public static implicit operator FreeMonad<C, TInput, TOutput>(C command)
        {
            return new FreeMonad<C, TInput, TOutput>(command, _ => Return(default));
        }
    }
}
