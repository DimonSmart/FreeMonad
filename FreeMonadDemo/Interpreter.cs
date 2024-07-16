using FreeMonadDemo;

public class Interpreter
{
    public T Interpret<T>(IFree<T> operation)
    {
        switch (operation)
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
            case Pure<T> pure:
                return pure.Value;
        }

        return default;
    }
}
