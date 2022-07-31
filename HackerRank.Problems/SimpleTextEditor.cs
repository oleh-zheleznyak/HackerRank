using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems
{
    public class SimpleTextEditor
    {
        public string ExecuteOperations(IOperationFactory operationFactory)
        {
            var state = new StringBuilder();
            var operations = operationFactory.Create();
            foreach (var op in operations) op.Apply(state);
            return state.ToString();
        }
    }

    public class OperationFactory : IOperationFactory
    {
        private readonly Func<string?> readNext;

        public OperationFactory(Func<string?> readNext)
        {
            this.readNext = readNext;
        }

        public OperationFactory(IEnumerable<string?> operationsFeed)
        {
            var enumerator = operationsFeed.GetEnumerator();
            var hasElements = enumerator.MoveNext();
            this.readNext = () =>
            {
                if (!hasElements) return null;
                while (hasElements) { var value = enumerator.Current; hasElements = enumerator.MoveNext(); return value; };
                return null; 
            };
        }

        public Operation[] Create()
        {
            var numberOfQueries = readNext();
            if (numberOfQueries is null || !int.TryParse(numberOfQueries, out var q)) throw new InvalidOperationException("invalid number of queries");
            var undoableCommands = new Stack<Undoable>();
            var operations = Enumerable.Range(0, q).Select(x => CreateFromString(readNext(), undoableCommands));
            return operations.ToArray();
        }

        private Operation CreateFromString(string? operation, Stack<Undoable> undoableCommands)
        {
            if (operation == null) throw new ArgumentNullException(nameof(operation));
            var op = operation.Split(' ');
            if (op.Length == 0) throw new ArgumentException($"wrong operation format: {operation}");
            if (!int.TryParse(op[0], out var opCode)) throw new ArgumentException($"wrong operation code: {operation}");

            switch (opCode)
            {
                case 1:
                    {
                        var append = new AppendToEnd(op[1]);
                        undoableCommands.Push(append);
                        return append;
                    }
                case 2:
                    {
                        var delete = new DeleteFromEnd(int.Parse(op[1])); // TODO: validate first index
                        undoableCommands.Push(delete);
                        return delete;
                    }
                case 3: return new PrintAtIndex(int.Parse(op[1]));
                case 4:
                    {
                        if (undoableCommands.Count == 0) throw new InvalidOperationException("Nothing to undo");
                        var undoable = undoableCommands.Pop();
                        var undo = new Undo(undoable);
                        return undo;
                    }

            }
            throw new ArgumentException($"invalid operation code number {opCode}");
        }
    }

    public interface Operation
    {
        void Apply(StringBuilder sb);
    }

    public interface Undoable : Operation
    {
        void Undo(StringBuilder sb);
    }

    public class AppendToEnd : Operation, Undoable
    {
        public AppendToEnd(string text)
        {
            this.text = text;
        }
        private readonly string text;

        public void Apply(StringBuilder sb)
        {
            sb.Append(text);
        }

        public void Undo(StringBuilder sb)
        {
            sb.Remove(sb.Length - text.Length, text.Length);
        }
    }

    public class DeleteFromEnd : Operation, Undoable
    {
        public DeleteFromEnd(int howMany)
        {
            this.howMany = howMany;
        }
        private readonly int howMany;
        private char[] removed = null;

        public void Apply(StringBuilder sb)
        {
            removed = new char[howMany];
            sb.CopyTo(sb.Length - howMany, removed, 0, howMany);
            sb.Remove(sb.Length - howMany, howMany);
        }

        public void Undo(StringBuilder sb)
        {
            sb.Append(removed);
        }
    }

    public class PrintAtIndex : Operation
    {
        public PrintAtIndex(int index)
        {
            this.index = index;
        }
        private readonly int index;

        public void Apply(StringBuilder sb)
        {
            Console.WriteLine(sb[index-1]);
        }
    }
    public class Undo : Operation
    {
        private readonly Undoable undoableOperation;

        public Undo(Undoable undoableOperation)
        {
            this.undoableOperation = undoableOperation;
        }

        public void Apply(StringBuilder sb)
        {
            undoableOperation.Undo(sb);
        }
    }
}
