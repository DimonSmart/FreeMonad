using FreeMonadDemo;

public class Interpreter : BaseInterpreter
{
    public override T InterpretCommand<T>(ICommand<T> command)
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
