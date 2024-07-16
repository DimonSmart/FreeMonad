using FreeMonadDemo;

public class Interpreter
{
    public T Interpret<T>(IFree<T> operation)
    {
        switch (operation)
        {
            case Free<T> free:
                return Interpret(free.Next);

            case Pure<T> pure:
                return pure.Value;

            default:
                throw new InvalidOperationException("Unsupported operation type");
        }
    }

    public T Interpret<T>(ICommand<T> command)
    {
        switch (command)
        {
            case GetText<T> getText:
                var result = getText.Text;
                return Interpret(getText.NextF(result));

            case UpperCase<T> upperCase:
                var inputText = upperCase.Input.ToUpper();
                return Interpret(upperCase.NextF(inputText));

            case WriteLine<T> writeLine:
                Console.WriteLine(writeLine.Message);
                return Interpret(writeLine.NextF(Unit.Value));

            default:
                throw new InvalidOperationException("Unsupported command type");
        }
    }
}
