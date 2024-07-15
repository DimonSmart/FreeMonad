//namespace FreeMonadDemo
//{
//    /// <summary>
//    /// An interpreter that executes the given commands.
//    /// </summary>
//    public class Interpreter : IInterpreter
//    {
//        public TOutput Execute<TInput, TOutput>(ICommand<TInput, TOutput> command, TInput input)
//        {
//            if (command is WriteLine writeLineCommand)
//            {
//                Console.WriteLine(writeLineCommand.Message);
//                return (TOutput)(object)Unit.Value;
//            }

//            if (command is UpperCase upperCaseCommand)
//            {
//                return (TOutput)(object)upperCaseCommand.Input.ToUpper();
//            }

//            if (command is GetAppleText getAppleTextCommand)
//            {
//                return (TOutput)(object)GetAppleText.Text;
//            }

//            throw new InvalidOperationException("Unknown command");
//        }
//    }

//}