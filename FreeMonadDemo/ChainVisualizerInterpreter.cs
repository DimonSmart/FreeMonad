using System.Text;

namespace FreeMonadDemo
{
    public class ChainVisualizerInterpreter : BaseInterpreter
    {
        private int _nodeCounter;
        private List<(string, string, string)> _edges;
        private string? _previousNode;
        public string LastCallGraph { get; private set; }

        public ChainVisualizerInterpreter()
        {
            _nodeCounter = 0;
            _edges = new List<(string, string, string)>();
            LastCallGraph = string.Empty;
            _previousNode = null;
        }

        public override T InterpretCommand<T>(ICommand<T> command)
        {
            var currentNode = GenerateNodeName(command);

            if (_previousNode != null)
            {
                _edges.Add((_previousNode, currentNode, GetLabel(command)));
            }
            _previousNode = currentNode;

            switch (command)
            {
                case GetText<T> getText:
                    var result = getText.Text;
                    return Interpret(getText.NextF(result));

                case UpperCase<T> upperCase:
                    var inputText = upperCase.Input.ToUpper();
                    return Interpret(upperCase.NextF(inputText));

                case WriteLine<T> writeLine:
                    return Interpret(writeLine.NextF(Unit.Value));

                default:
                    throw new InvalidOperationException("Unsupported command type");
            }
        }

        protected override void PostInterpret() => GenerateCallGraph();

        private string GenerateNodeName<T>(ICommand<T> command) =>
            $"{GetSimpleTypeName(command.GetType())}_{_nodeCounter++}";

        private string GetLabel<T>(ICommand<T> command)
        {
            switch (command)
            {
                case GetText<T> getText:
                    return EscapeLabel($"GetText(\"{getText.Text}\")");
                case UpperCase<T> upperCase:
                    return EscapeLabel($"UpperCase(\"{upperCase.Input}\")"); ;
                case WriteLine<T> writeLine:
                    return EscapeLabel($"WriteLine(\"{writeLine.Message}\")");
                default:
                    return string.Empty;
            }
        }

        private static string EscapeLabel(string label) => label.Replace("\"", "\\\"");

        private string GetSimpleTypeName(Type type)
        {
            if (type.IsGenericType)
            {
                var genericTypeName = type.GetGenericTypeDefinition().Name;
                var genericArguments = type.GetGenericArguments();
                return $"{genericTypeName.Substring(0, genericTypeName.IndexOf('`'))}";
            }
            return type.Name;
        }

        private void GenerateCallGraph()
        {
            var sb = new StringBuilder();
            sb.AppendLine("digraph CallGraph {");
            foreach (var edge in _edges)
            {
                sb.AppendLine($"    {edge.Item1} -> {edge.Item2} [label=\"{edge.Item3}\"];");
            }
            sb.AppendLine("}");
            LastCallGraph = sb.ToString();
        }
    }
}