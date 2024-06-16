namespace FreeMonadDemo
{
    public class FreeMonad<C>
    {
        public C Command { get; private set; }
        public Func<object, FreeMonad<C>> Next { get; private set; }

        public FreeMonad(C command, Func<object, FreeMonad<C>> next)
        {
            Command = command;
            Next = next;
        }

        public static FreeMonad<C> Return()
        {
            return null;
        }

        public static FreeMonad<C> WrapAsMonad(C command)
        {
            return new FreeMonad<C>(command, _ => Return());
        }
    }
}