namespace FreeMonadDemo
{
    public class ConsoleFreeMonadInterpreter : IFreeMonadInterpreter
    {
        public void Interpret(FreeMonad<ICommand> program)
        {
            while (program != null)
            {
                switch (program.Command)
                {
                    case WriteLine w:
                        Console.WriteLine(w.Message);
                        break;
                }
                program = program.Next(null);
            }
        }
    }
}