namespace FreeMonadDemo
{
    /// <summary>
    /// Defines an interpreter that can execute commands of type ICommand.
    /// </summary>
    public interface IInterpreter
    {
        /// <summary>
        /// Executes a given command with the specified input.
        /// </summary>
        /// <typeparam name="TInput">The type of the input parameter.</typeparam>
        /// <typeparam name="TOutput">The type of the result produced by the command.</typeparam>
        /// <param name="command">The command to be executed.</param>
        /// <param name="input">The input parameter for the command.</param>
        /// <returns>Result of the command execution.</returns>
        TOutput Execute<TInput, TOutput>(ICommand<TInput, TOutput> command, TInput input);
    }
}
