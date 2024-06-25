namespace FreeMonadDemo
{

    /// <summary>
    /// Represents a command that accepts an input parameter of type TInput and produces a result of type TOutput.
    /// </summary>
    /// <typeparam name="TInput">The type of the input parameter.</typeparam>
    /// <typeparam name="TOutput">The type of the result produced by the command.</typeparam>
    /// <remarks>
    /// This interface does not include an Execute method because the responsibility of executing the command is delegated to the interpreter. 
    /// This design allows the Free Monad to separate the description of the commands from their execution, enabling more flexible and composable program structures.
    /// </remarks>
    public interface ICommand<TInput, TOutput>
    {
        // No need for an Execute method here
    }
}